/*
 * Dye & Durham Name-Sorter Tests (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: NameSorterTests.cs
 * Description	: Class used for testing the "name-sorter" class.
 */
namespace NameSorter.Tests;

using Xunit;
using NameSorter.Services;


public class NameSorterTests
{
    /// ***********************************************************************
    /// <summary>
    /// Test sorter on invalid names.
    /// </summary>
    /// ***********************************************************************
    [Fact]
    public void Sort_ShouldReturnInvalidSortedNames()
    {
        // Arrange
        var unsortedNames = new List<string> { "Matthew Wood", "A", "Joe Bloggs", "Jane Smith" };
        var sortedNames = new List<string> { $"{NameValidator.EInvalidNameFormat} (A)", "Joe Bloggs", "Jane Smith", "Matthew Wood" };
        var nameValidator = new NameValidator(default);
        var nameSorter = new NameSorter(default, nameValidator);

        // Act
        var result = nameSorter.Sort(unsortedNames);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(sortedNames, result);
    }


    /// ***********************************************************************
    /// <summary>
    /// Test sorter on valid names.
    /// </summary>
    /// ***********************************************************************
    [Fact]
    public void Sort_ShouldReturnValidSortedNames()
    {
        // Arrange
        var unsortedNames = new List<string> { "Matthew Wood", "Adam Wood", "Joe Bloggs", "Jane Smith" };
        var sortedNames = new List<string> { "Joe Bloggs", "Jane Smith", "Adam Wood", "Matthew Wood" };
        var nameValidator = new NameValidator(default);
        var nameSorter = new NameSorter(default, nameValidator);

        // Act
        var result = nameSorter.Sort(unsortedNames);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(sortedNames, result);
    }
}
