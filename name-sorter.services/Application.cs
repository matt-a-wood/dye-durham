/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: Application.cs
 * Description	: Class used for a application.
 */
namespace NameSorter.Services;

using Microsoft.Extensions.Logging;


public class Application : Service, IApplication
{
    // Default log messages.
    internal const string LogErrorNoNames = "No names found in file '{inputFilePath}'.";


    /// ***********************************************************************
    /// <summary>
    /// Gets/Sets the save-invalid-names flag.
    /// </summary>
    /// ***********************************************************************
    public bool SaveInvalidNames { get; init; } = default;


    /// ***********************************************************************
    /// <summary>
    /// Gets/Sets the name-sorter.
    /// </summary>
    /// ***********************************************************************
    protected INameSorter NameSorter { get; init; }


    /// ***********************************************************************
    /// <summary>
    /// Gets/Sets the file-reader.
    /// </summary>
    /// ***********************************************************************
    protected IFileReader FileReader { get; init; }


    /// ***********************************************************************
    /// <summary>
    /// Gets/Sets the file-writer.
    /// </summary>
    /// ***********************************************************************
    protected IFileWriter FileWriter { get; init; }


    /// ***********************************************************************
    /// <summary>
    /// Default constructor to pass in dependencies.
    /// </summary>
    /// 
    /// <param name="logger">
    /// The logger to use for application logging.
    /// </param>
    /// 
    /// <param name="nameSorter">
    /// The name-sorter to use for sorting the list of names read from the
    /// file-reader.
    /// </param>
    /// 
    /// <param name="fileReader">
    /// The file-reader to use for reading an input-file of names.
    /// </param>
    ///
    /// <param name="fileWriter">
    /// The file-writer to use for writing an output-file of sorted names.
    /// </param>
    /// ***********************************************************************
    public Application(
        ILogger<IApplication>? logger,
        INameSorter nameSorter,
        IFileReader fileReader,
        IFileWriter fileWriter) : base(logger)
    {
        NameSorter = nameSorter;
        FileReader = fileReader;
        FileWriter = fileWriter;
    }


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
    public virtual async Task<IEnumerable<string>?> SortNamesAsync(
        string inputFilePath,
        string outputFilePath)
    {
        // Read the list of names from the file.
        Logger?.LogExecute();
        var orignalNames = await FileReader.ReadFileAsync(inputFilePath);
        if (!orignalNames?.Any() ?? true)
        {
            Logger?.LogError(LogErrorNoNames, inputFilePath);
            return default;
        }

        // Sort the names.
        var sortedNames = NameSorter.Sort(orignalNames!);
        await FileWriter.WriteFileAsync(
            outputFilePath,
            SaveInvalidNames ? sortedNames : sortedNames.Where(name => !name.StartsWith("ERROR")));

        // Return the sorted list of names.
        return sortedNames;
    }
}
