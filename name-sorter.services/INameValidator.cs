/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: INameValidator.cs
 * Description	: Interface abstraction for a name-validator.
 */
namespace NameSorter.Services;

public interface INameValidator
{
    /// ***********************************************************************
    /// <summary>
    /// Check if specified list of names/words is valid.
    /// </summary>
    /// 
    /// <param name="names">
    /// The list of names/words to be validated.
    /// </param>
    /// ***********************************************************************
    string IsValidName(
        IEnumerable<string> names);
}
