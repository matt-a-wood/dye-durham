/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: NameSorter.cs
 * Description	: Class used for a name-sorter.
 */
namespace NameSorter.Services;

using Microsoft.Extensions.Logging;
using System.Xml.Linq;


public class NameSorter : Service, INameSorter
{
    /// ***********************************************************************
    /// <summary>
    /// Gets/Sets the Separator (used for splitting text into names/words).
    /// </summary>
    /// ***********************************************************************
    public char Separator { get; set; } = ' ';


    /// ***********************************************************************
    /// <summary>
    /// Gets/Sets the logger.
    /// </summary>
    /// ***********************************************************************
    protected INameValidator NameValidator { get; init; }


    /// ***********************************************************************
    /// <summary>
    /// Default constructor to pass in dependencies.
    /// </summary>
    /// 
    /// <param name="logger">
    /// The logger to use for application logging.
    /// </param>
    /// 
    /// <param name="nameValidator">
    /// The (name) validator to use for validating each name to be sorted.
    /// </param>
    /// ***********************************************************************
    public NameSorter(
        ILogger<INameSorter>? logger,
        INameValidator nameValidator) : base(logger)
    {
        NameValidator = nameValidator;
    }


    /// ***********************************************************************
    /// <summary>
    /// Sorts the specified list of names, alphabetically.
    /// </summary>
    /// 
    /// <param name="names">
    /// The list of names to be sorted.
    /// </param>
    /// ***********************************************************************
    public virtual IEnumerable<string> Sort(
        IEnumerable<string> names)
    {
        Logger?.LogExecute();
        return !names.Any()
            ? names
            : names.Select(name =>
            {
                // Get the names from the current name/line.
                var words = name.Trim().Split(Separator, StringSplitOptions.RemoveEmptyEntries);
                
                // Check for a valid "name".
                var errorMessage = NameValidator.IsValidName(words);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    // Log the invalid name encountered.
                    // NOTE: Using message template to avoid CA2254 warning due
                    // du generating dynamic name error message.  Refer to:
                    // https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca2254
                    Logger?.LogError("{Message}", new Name
                    {
                        FullName = name,
                        ErrorMessage = errorMessage
                    }.ToString());
                }

                // Add the name to the list to be sorted.
                return string.IsNullOrEmpty(errorMessage)
                    // Add non-empty line of words as name.
                    ? new Name
                    {
                        FullName = name,
                        FirstName = words.Length > 1 ? string.Join(Separator, words.Take(words.Length - 1)) : words[0],
                        Surname = words.Length > 1 ? words.Last() : string.Empty,
                        ErrorMessage = string.Empty
                    }

                    // Add dummy/empty line of words as name and add error
                    // message.
                    : new Name
                    {
                        FullName = name,
                        FirstName = string.Empty,
                        Surname = string.Empty,
                        ErrorMessage = errorMessage
                    };
            })
            .OrderBy(name => name.Surname, StringComparer.OrdinalIgnoreCase)
            .ThenBy(name => name.FirstName, StringComparer.OrdinalIgnoreCase)
            .ThenBy(name => name.ErrorMessage, StringComparer.OrdinalIgnoreCase)
            .ThenBy(name => name.FullName, StringComparer.OrdinalIgnoreCase)
            .Select(name => name.ToString());
    }
}
