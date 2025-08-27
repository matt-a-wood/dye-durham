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
    // Default log messages.
    internal const string LogBeginWriteFile     = "Writing file '{filePath}'.";
    internal const string LogEndWriteFile       = "Wrote {lineCount} lines to file '{filePath}'.";
    internal const string LogErrorWriteFile     = "Could not write file '{filePath}'.  Reason: {reason}.";
    internal const string LogCancelWriteFile    = "File write was cancelled.";


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
        Logger?.LogExecute();
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
        Logger?.LogExecute();
        try
        {
            // Write all text lines to the file.
            Logger?.LogInformation(LogBeginWriteFile, filePath);
            await File.WriteAllLinesAsync(
                filePath,
                lines,
                encoding,
                cancellationToken);

            // Return the file contents if Write successfully, otherwise return 
            // null results to indication a cancellation was requested.
            if (cancellationToken.IsCancellationRequested)
            {
                Logger?.LogWarning(LogCancelWriteFile);
                return default;
            }
            else
            {
                var lineCount = lines.Count();
                Logger?.LogInformation(LogEndWriteFile, lineCount, filePath);
                return lineCount;
            }
        }
        catch (OperationCanceledException)
        {
            // Cancellation exception was thrown!
            Logger?.LogWarning(LogCancelWriteFile);
            return default;
        }
        catch (IOException ex)
        {
            // File IO exception was thrown!
            Logger?.LogError(LogErrorWriteFile, filePath, ex.Message);
            throw;
        }
    }
}
