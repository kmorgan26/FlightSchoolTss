using FlightSchoolTss.Data.Validators.Maintainer;
using FlightSchoolTss.Data.DTOs.Maintainer;

namespace FlightSchoolTss.Tests.Validators;
public class CreateMaintainerDtoValidatorTests
{
    [Fact]
    public async Task Validate_WithValidDto_ReturnsTrue()
    {
        // Arrange
        var validator = new CreateMaintainerDtoValidator();
        var dto = new CreateMaintainerDto
        {
            Name = "John Doe"
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public async Task Validate_WithMissingName_ReturnsFalse()
    {
        // Arrange
        var validator = new CreateMaintainerDtoValidator();
        var dto = new CreateMaintainerDto
        {
            Name = ""
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CreateMaintainerDto.Name));
    }

    [Fact]
    public async Task Validate_WithInvalidNameLength_ReturnsFalse()
    {
        // Arrange
        var validator = new CreateMaintainerDtoValidator();
        var dto = new CreateMaintainerDto
        {
            Name = "A" // Name length less than the minimum length (3)
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CreateMaintainerDto.Name));
    }

    [Fact]
    public async Task Validate_WithExcessiveNameLength_ReturnsFalse()
    {
        // Arrange
        var validator = new CreateMaintainerDtoValidator();
        var dto = new CreateMaintainerDto
        {
            Name = "ThisIsAVeryLongName" // Name length exceeds the maximum length (15)
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CreateMaintainerDto.Name));
    }
}
