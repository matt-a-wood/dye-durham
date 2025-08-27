/*
 * Dye & Durham Name-Sorter Tests (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: ApplicationTests.cs
 * Description	: Class used for testing the "application" class.
 */
namespace NameSorter.Tests;

using Moq;
using Xunit;
using NameSorter.Services;


public class ApplicationTests
{
    /// ***********************************************************************
    /// <summary>
    /// Test for application sort-names on an empty file.
    /// </summary>
    /// ***********************************************************************
    [Fact]
    public async Task SortNamesAsync_ShouldReturnNoResultOnEmptyInputFile()
    {
        // Arrange
        var mockReader = new Mock<IFileReader>();
        mockReader.Setup(fileReader => fileReader
            .ReadFileAsync("dummyInputFile.txt"))
            .ReturnsAsync(default(IEnumerable<string>?));

        var mockWriter = new Mock<IFileWriter>();
        var mockSorter = new Mock<INameSorter>();
        var application = new Application(
            default,
            mockSorter.Object,
            mockReader.Object,
            mockWriter.Object);

        // Act
        var results = await application.SortNamesAsync(
            "dummyInputFile.txt",
            "dummyOutputFile.txt");

        // Assert
        Assert.Null(results);
    }


    /// ***********************************************************************
    /// <summary>
    /// Test for application sort-names on a valid "dummy" file.
    /// </summary>
    /// ***********************************************************************
    [Fact]
    public async Task SortNamesAsync_ShouldReturnSortedResultOnValidInputFile()
    {
        // Arrange
        var unsortedNames = new List<string> { "Matthew Wood", "Adam Wood", "Joe Bloggs", "Jane Smith" };
        var sortedNames = new List<string> { "Joe Bloggs", "Jane Smith", "Adam Wood", "Matthew Wood" };

        var mockReader = new Mock<IFileReader>();
        mockReader.Setup(fileReader => fileReader
            .ReadFileAsync("dummyInputFile.txt"))
            .ReturnsAsync(unsortedNames);

        var mockWriter = new Mock<IFileWriter>();
        mockWriter.Setup(fileWriter => fileWriter
            .WriteFileAsync("dummyOutputFile.txt", sortedNames))
            .ReturnsAsync(sortedNames.Count);

        var mockSorter = new Mock<INameSorter>();
        mockSorter.Setup(nameSorter => nameSorter
            .Sort(unsortedNames))
            .Returns(sortedNames);

        var application = new Application(
            default,
            mockSorter.Object,
            mockReader.Object,
            mockWriter.Object);

        // Act
        var results = await application.SortNamesAsync(
            "dummyInputFile.txt",
            "dummyOutputFile.txt");

        // Assert
        Assert.NotNull(results);
        Assert.Equal(sortedNames, results);
    }


    /// ***********************************************************************
    /// <summary>
    /// Test for application sort-names on a  mixed "dummy" file.
    /// </summary>
    /// 
    /// <remarks>
    /// NOTE: Intended to have valid and invalid name in dummy file!
    /// </remarks>
    /// ***********************************************************************
    [Fact]
    public async Task SortNamesAsync_ShouldReturnSortedResultOnMixedInputFile()
    {
        // Arrange
        var unsortedNames = new List<string> { "Matthew Wood", "Adam Wood", "B", "Joe Bloggs", "Jane Smith" };
        var sortedNames = new List<string> { $"{NameValidator.EInvalidNameFormat} (B)", "Joe Bloggs", "Jane Smith", "Adam Wood", "Matthew Wood" };

        var mockReader = new Mock<IFileReader>();
        mockReader.Setup(fileReader => fileReader
            .ReadFileAsync("dummyInputFile.txt"))
            .ReturnsAsync(unsortedNames);

        var mockWriter = new Mock<IFileWriter>();
        mockWriter.Setup(fileWriter => fileWriter
            .WriteFileAsync("dummyOutputFile.txt", sortedNames))
            .ReturnsAsync(sortedNames.Count);

        var mockSorter = new Mock<INameSorter>();
        mockSorter.Setup(nameSorter => nameSorter
            .Sort(unsortedNames))
            .Returns(sortedNames);

        var application = new Application(
            default,
            mockSorter.Object,
            mockReader.Object,
            mockWriter.Object);

        // Act
        var results = await application.SortNamesAsync(
            "dummyInputFile.txt",
            "dummyOutputFile.txt");

        // Assert
        Assert.NotNull(results);
        Assert.Equal(sortedNames, results);
    }
}
