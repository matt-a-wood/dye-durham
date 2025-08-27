/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: IFileReader.cs
 * Description	: Interface abstraction for a file-reader.
 */
namespace NameSorter.Services;

using System.Collections.Generic;
using System.Text;


public interface IFileReader
{
    /// ***********************************************************************
    /// <summary>
    /// Reads all lines from the specified file-path.
    /// </summary>
    /// 
    /// <param name="filePath">
    /// The file-path of the file to read from.
    /// </param>
    /// ***********************************************************************
    Task<IEnumerable<string>?> ReadFileAsync(
        string filePath);


    /// ***********************************************************************
    /// <summary>
    /// Reads all lines from the specified file-path, using the specified 
    /// encoding and cancellation-token.
    /// </summary>
    /// 
    /// <param name="filePath">
    /// The file-path of the file to read from.
    /// </param>
    /// 
    /// <param name="encoding">
    /// The encoding to use for writing to the file.
    /// </param>
    /// 
    /// <param name="cancellationToken">
    /// The cancellation-token to use for signalling a cancellation has been
    /// requested.
    /// </param>
    /// ***********************************************************************
    Task<IEnumerable<string>?> ReadFileAsync(
        string filePath,
        Encoding encoding,
        CancellationToken cancellationToken = default);
}
