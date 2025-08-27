/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: INameSorter.cs
 * Description	: Interface abstraction for a name-sorter.
 */
namespace NameSorter.Services;

public interface INameSorter
{
    /// ***********************************************************************
    /// <summary>
    /// Sorts the specified list of names, alphabetically.
    /// </summary>
    /// 
    /// <param name="names">
    /// The list of names to be sorted.
    /// </param>
    /// ***********************************************************************
    IEnumerable<string> Sort(
        IEnumerable<string> names);
}
