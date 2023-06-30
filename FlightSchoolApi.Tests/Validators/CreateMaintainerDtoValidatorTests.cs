using FlightSchoolTss.Data.Validators.Maintainer;
using FlightSchoolTss.Data.DTOs.Maintainer;

namespace FlightSchoolTss.Tests.Validators;
public class MaintainerDtoValidatorTests
{
    [Fact]
    public async Task Validate_WithValidDto_ReturnsTrue()
    {
        // Arrange
        var validator = new MaintainerDtoValidator();
        var dto = new MaintainerDto
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
        var validator = new MaintainerDtoValidator();
        var dto = new MaintainerDto
        {
            Name = ""
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(MaintainerDto.Name));
    }

    [Fact]
    public async Task Validate_WithInvalidNameLength_ReturnsFalse()
    {
        // Arrange
        var validator = new MaintainerDtoValidator();
        var dto = new MaintainerDto
        {
            Name = "A" // Name length less than the minimum length (3)
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(MaintainerDto.Name));
    }

    [Fact]
    public async Task Validate_WithExcessiveNameLength_ReturnsFalse()
    {
        // Arrange
        var validator = new MaintainerDtoValidator();
        var dto = new MaintainerDto
        {
            Name = "ThisIsAVeryLongName" // Name length exceeds the maximum length (15)
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(MaintainerDto.Name));
    }
}
