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
    // Default log messages.
    internal const string LogBeginReadFile  = "Reading file '{filePath}'.";
    internal const string LogEndReadFile    = "Read {lineCount} lines from file '{filePath}'.";
    internal const string LogErrorReadFile  = "Could not read file '{filePath}'.  Reason: {reason}.";
    internal const string LogCancelReadFile = "File read was cancelled.";


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
        Logger?.LogExecute();
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
        Logger?.LogExecute();
        try
        {
            // Read all text lines from the file.
            Logger?.LogInformation(LogBeginReadFile, filePath);
            var result = await File.ReadAllLinesAsync(
                filePath,
                encoding,
                cancellationToken);

            // Return the file contents if read successfully, otherwise return 
            // null results to indication a cancellation was requested.
            if (cancellationToken.IsCancellationRequested)
            {
                Logger?.LogWarning(LogCancelReadFile);
                return default;
            }
            else
            {
                Logger?.LogInformation(LogEndReadFile, result.Length, filePath);
                return result;
            }
        }
        catch (OperationCanceledException)
        {
            // Cancellation exception was thrown!
            Logger?.LogWarning(LogCancelReadFile);
            return default;
        }
        catch (IOException ex)
        {
            // File IO exception was thrown!
            Logger?.LogError(LogErrorReadFile, filePath, ex.Message);
            throw;
        }
    }
}
