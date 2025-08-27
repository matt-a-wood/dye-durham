/*
 * Dye & Durham Name-Sorter Tests (Coding Assessment).
 * Copyright (c) Matthew Wood, 2025.
 * 
 * File			: NameValidatorTests.cs
 * Description	: Class used for testing the "name-validator" class.
 */
namespace NameSorter.Tests;

using Xunit;
using NameSorter.Services;


public class NameValidatorTests
{
    /// ***********************************************************************
    /// <summary>
    /// Test validator for an invalid name.
    /// </summary>
    /// ***********************************************************************
    [Fact]
    public void IsValidName_ShouldReturnInvalidNameErrorMessageForNoNames()
    {
        // Arrange
        var nameValidator = new NameValidator(default);

        // Act
        var result = nameValidator.IsValidName(new List<string>());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(NameValidator.EInvalidNameFormat, result);
    }


    /// ***********************************************************************
    /// <summary>
    /// Test validator for an invalid name.
    /// </summary>
    /// ***********************************************************************
    [Fact]
    public void IsValidName_ShouldReturnInvalidNameErrorMessageForOneName()
    {
        // Arrange
        var nameValidator = new NameValidator(default);

        // Act
        var result = nameValidator.IsValidName(new List<string> { "Matt" });

        // Assert
        Assert.NotNull(result);
        Assert.Equal(NameValidator.EInvalidNameFormat, result);
    }


    /// ***********************************************************************
    /// <summary>
    /// Test validator a valid name (using 3 names).
    /// </summary>
    /// ***********************************************************************
    [Fact]
    public void IsValidName_ShouldReturnNoErrorMessageForValidName()
    {
        // Arrange
        var nameValidator = new NameValidator(default);

        // Act
        var result = nameValidator.IsValidName(new List<string> { "Matthew", "A", "Wood" });

        // Assert
        Assert.Null(result);
    }
}
