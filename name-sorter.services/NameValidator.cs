/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: INameValidator.cs
 * Description	: Interface abstraction for a name-validator.
 */
namespace NameSorter.Services;

using Microsoft.Extensions.Logging;

public class NameValidator : Service, INameValidator
{
    // Defaults
    public const string EInvalidNameFormat  = "ERROR: Invalid Name format";
    public const int MinimumNameCount       = 2;
    public const int MaximumNameCount       = 4;


    /// ***********************************************************************
    /// <summary>
    /// Default constructor to pass in dependencies.
    /// </summary>
    /// 
    /// <param name="logger">
    /// The logger to use for application logging.
    /// </param>
    /// ***********************************************************************
    public NameValidator(
        ILogger<INameValidator>? logger) : base(logger)
    {
    }


    /// ***********************************************************************
    /// <summary>
    /// Check if specified list of names/words is valid.
    /// </summary>
    /// 
    /// <param name="names">
    /// The list of names/words to be validated.
    /// </param>
    /// ***********************************************************************
    public virtual string IsValidName(
        IEnumerable<string> names)
    {
        Logger?.LogExecute();
        var nameCount = names.Count();
        if ((nameCount >= MinimumNameCount) && (nameCount <= MaximumNameCount))
        {
            return default!;
        }

        return EInvalidNameFormat;
    }
}
