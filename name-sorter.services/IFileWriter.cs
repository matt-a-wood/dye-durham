/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: IFileWriter.cs
 * Description	: Interface abstraction for a file-writer.
 */
namespace NameSorter.Services;

using System.Collections.Generic;
using System.Text;


public interface IFileWriter
{
    /// ***********************************************************************
    /// <summary>
    /// Writes the specified lines to the specified file-path.
    /// </summary>
    /// 
    /// <param name="filePath">
    /// The file-path of the file to write to.
    /// </param>
    /// 
    /// <param name="lines">
    /// The lines to write to the file.
    /// </param>
    /// ***********************************************************************
    Task<int> WriteFileAsync(
        string filePath,
        IEnumerable<string> lines);


    /// ***********************************************************************
    /// <summary>
    /// Writes the specified lines to the specified file-path, using the 
    /// specified encoding and cancellation-token.
    /// </summary>
    /// 
    /// <param name="filePath">
    /// The file-path of the file to write to.
    /// </param>
    /// 
    /// <param name="lines">
    /// The lines to write to the file.
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
    Task<int> WriteFileAsync(
        string filePath,
        IEnumerable<string> lines,
        Encoding encoding,
        CancellationToken cancellationToken = default);
}
