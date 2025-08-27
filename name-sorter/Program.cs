/*
 * Dye & Durham Name-Sorter Console (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: Program.cs
 * Description	: Class used for the main program (console application).
 */
namespace NameSorter;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.IO.Pipelines;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    // Defaults
    internal const string DefaultOutputFileName = "sorted-names-list.txt";
    internal const string DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss";


    /// ***********************************************************************
    /// <summary>
    /// Main application entry point.
    /// </summary>
    /// 
    /// <param name="args">
    /// The command-line args to pass to the application.
    /// </param>
    /// ***********************************************************************
    public static async Task Main(string[] args)
    {
        // Path where this app is runnning!
        var executablePath = System.AppContext.BaseDirectory;

        // Check for correct cammand-line args.
        if (args.Length < 1)
        {
            Console.WriteLine(
                "Usage: {0} [InputFilePath] [OutputFilePath]",
                Path.GetFileNameWithoutExtension(executablePath));

            Console.WriteLine();
            Console.WriteLine("InputFilePath    Input file path (required)");
            Console.WriteLine("OutputFilePath   Output file path (optional)");
            return;
        }

        // Create and run the app!
        using (var host = CreateHost(args))
        {
            // Allow for Ctrl+C to stop execution.
            host
                .Services
                .GetRequiredService<IHostApplicationLifetime>()
                .ApplicationStopping
                .Register(() =>
                {
                    Console.WriteLine("Ctrl+C pressed. Application stopping...");
                });

            // Execute the app (read input file, sort names, and write output file).
            // TODO: Add app logic/execution here!
            try
            {
                // Get input and out file path's.
                var inputFilePath = GetFilePath(args[0]);
                var outputFilePath = GetFilePath((args.Length == 2) 
                    ? args[1] 
                    : DefaultOutputFileName);

                // Get/run the app.
                // TODO: Add app logic/exection here!
            }
            catch (Exception ex)
            {
                // TODO: Handle exceptions here!
            }
        }
    }


    /// ***********************************************************************
    /// <summary>
    /// Creates the console application host.
    /// </summary>
    /// 
    /// <param name="args">
    /// The command-line args to pass to the application/host.
    /// </param>
    /// ***********************************************************************
    private static IHost CreateHost(
        string[] args)
    {
        // Create the app/host builder.
        var builder = Host.CreateApplicationBuilder(args);

        // Register/configure logging.
        builder.Logging
            .AddConsole(configure =>
            {
                configure.LogToStandardErrorThreshold = LogLevel.None;
                configure.FormatterName = ConsoleFormatterNames.Simple;
            })
            .AddSimpleConsole(configure =>
            {
                configure.IncludeScopes = true;
                configure.SingleLine = true;
                configure.TimestampFormat = DefaultDateTimeFormat;
            });

        // Build and return the host.
        return builder.Build();
    }


    /// ***********************************************************************
    /// <summary>
    /// Gets the specified file-path as a full-file-path, relative to the
    /// app execution path, if it doesn't contain an existing path.
    /// </summary>
    /// 
    /// <param name="filePath">
    /// The file-path to use/check for existing full path (or prefix with
    /// execution path).
    /// </param>
    /// ***********************************************************************
    private static string GetFilePath(
        string filePath)
    {
        // Path where this app is runnning!
        var executablePath = System.AppContext.BaseDirectory;

        if (string.IsNullOrEmpty(Path.GetDirectoryName(filePath)))
        {
            filePath = Path.Combine(executablePath!, filePath);
        }
        return filePath;
    }
}
