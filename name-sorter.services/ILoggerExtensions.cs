/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: ILoggerExtensions.cs
 * Description	: Class used for implementing extensions to the standard .NET 
 *				  ILogger interface.
 */
namespace NameSorter.Services;

using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;


internal static class ILoggerExtensions
{
    // Default log messages.
    internal const string LogExecution = "Executing {0}";


    /// ***********************************************************************
    /// <summary>
    /// Writes a log message to indicate the "execution" of a "method".
    /// </summary>
    /// 
    /// <param name="self">
    /// The instance of the ILogger to use for this extension method.
    /// </param>
    /// 
    /// <param name="callerName">
    /// The caller-name to use as the caller of this method.
    /// </param>
    /// ***********************************************************************
    public static void LogExecute(
        this ILogger? self,
        [CallerMemberName] string callerName = default!)
    {
        self?.LogInformation(LogExecution, callerName);
    }
}



