/*
 * Dye & Durham Name-Sorter Services (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: Service.cs
 * Description	: Base class used for a "service".
 */
namespace NameSorter.Services;

using Microsoft.Extensions.Logging;


public class Service
{
    /// ***********************************************************************
    /// <summary>
    /// Gets/Sets the logger.
    /// </summary>
    /// ***********************************************************************
    protected ILogger? Logger { get; init; }


    /// ***********************************************************************
    /// <summary>
    /// Default constructor to pass in dependencies.
    /// </summary>
    /// 
    /// <param name="logger">
    /// The logger to use for application logging.
    /// </param>
    /// ***********************************************************************
    protected Service(
        ILogger? logger)
    {
        Logger = logger;
    }
}
