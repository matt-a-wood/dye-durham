/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: FileWriter.cs
 * Description	: Class used for a file-writer.
 */
namespace NameSorter.Services;

using Microsoft.Extensions.Logging;
using System.Text;


public class FileWriter : Service, IFileWriter
{
    /// ***********************************************************************
    /// <summary>
    /// Default constructor to pass in dependencies.
    /// </summary>
    /// 
    /// <param name="logger">
    /// The logger to use for application logging.
    /// </param>
    /// ***********************************************************************
    public FileWriter(
        ILogger<IFileWriter>? logger) : base(logger)
    {
    }


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
    public async Task<int> WriteFileAsync(
        string filePath,
        IEnumerable<string> lines)
    {
        return await WriteFileAsync(
            filePath,
            lines,
            Encoding.Default,
            CancellationToken.None);
    }


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
    public virtual async Task<int> WriteFileAsync(
        string filePath,
        IEnumerable<string> lines,
        Encoding encoding,
        CancellationToken cancellationToken = default)
    {
        await Task.Delay(1000, cancellationToken);
        throw new NotImplementedException();
    }
}
