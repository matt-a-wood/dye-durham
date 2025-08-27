/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: FileReader.cs
 * Description	: Class used for a file-reader.
 */
namespace NameSorter.Services;

using Microsoft.Extensions.Logging;
using System.Text;


public class FileReader : Service, IFileReader
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
    public FileReader(
        ILogger<IFileReader>? logger) : base(logger)
    {
    }


    /// ***********************************************************************
    /// <summary>
    /// Reads all lines from the specified file-path.
    /// </summary>
    /// 
    /// <param name="filePath">
    /// The file-path of the file to read from.
    /// </param>
    /// ***********************************************************************
    public async Task<IEnumerable<string>?> ReadFileAsync(
        string filePath)
    {
        return await ReadFileAsync(
            filePath,
            Encoding.Default,
            CancellationToken.None);
    }


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
    public virtual async Task<IEnumerable<string>?> ReadFileAsync(
        string filePath,
        Encoding encoding,
        CancellationToken cancellationToken = default)
    {
        await Task.Delay(1000, cancellationToken);
        throw new NotImplementedException();
    }
}
