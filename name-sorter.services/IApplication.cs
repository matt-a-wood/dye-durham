/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: IApplication.cs
 * Description	: Interface abstraction for a application.
 */
namespace NameSorter.Services;


public interface IApplication
{
    /// ***********************************************************************
    /// <summary>
    /// Reads a list of names from the specified input-file-path, sorts the
    /// names, and the writes sorted names back to the specified output-file-
    /// path.
    /// </summary>
    /// 
    /// <param name="inputFilePath">
    /// The file-path to use for reading the input file.
    /// </param>
    /// 
    /// <param name="outputFilePath">
    /// The file-path to use for writing the output file.
    /// </param>
    /// 
    /// <remarks>
    /// NOTE: This list of sorted names is returned so they can be used/
    /// consumed/displayed by the caller.
    /// </remarks>
    /// ***********************************************************************
    Task<IEnumerable<string>?> SortNamesAsync(
        string inputFilePath,
        string outputFilePath);
}
