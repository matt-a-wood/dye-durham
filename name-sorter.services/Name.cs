/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: Name.cs
 * Description	: Class used for a "name".
 */
namespace NameSorter.Services;


public class Name
{
    public string FullName { get; init; } = default!;
    public string FirstName { get; init; } = default!;
    public string Surname { get; init; } = default!;
    public string ErrorMessage { get; init; } = default!;


    /// ***********************************************************************
    /// <summary>
    /// Return the name as a full-name, or an optional error-message and full-
    /// name.
    /// </summary>
    /// ***********************************************************************
    public override string ToString()
    {
        return string.IsNullOrEmpty(ErrorMessage)
            ? FullName
            : $"{ErrorMessage} ({FullName})";
    }
}
