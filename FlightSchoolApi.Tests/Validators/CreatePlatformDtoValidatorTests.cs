using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.DTOs.Platform;
using FlightSchoolTss.Data.Validators.Platform;
using FluentValidation;
using Moq;

namespace FlightSchoolTss.Tests.Validators;
public class CreatePlatformDtoValidatorTests
{
    private readonly Mock<IPlatformRepository> _mockRepository;

    public CreatePlatformDtoValidatorTests()
    {
        _mockRepository = new Mock<IPlatformRepository>();
    }

    //[Fact]
    //public async Task Validate_WithValidDto_ReturnsTrue()
    //{
    //    // Arrange
    //    var validator = new CreatePlatformDtoValidator(_mockRepository.Object);

    //    var dto = new CreatePlatformDto
    //    {
    //        Name = "ValidName",
    //        MaintainerId = 1,
    //        IsActive = true
    //    };

    //    // Act
    //    var result = await validator.ValidateAsync(dto);

    //    // Assert
    //    Assert.True(result.IsValid);
    //}

    [Fact]
    public async Task Validate_WithMissingName_ReturnsFalse()
    {
        // Arrange
        var validator = new CreatePlatformDtoValidator(_mockRepository.Object);
        var dto = new CreatePlatformDto
        {
            Name = "", // Empty name
            MaintainerId = 1
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CreatePlatformDto.Name));
    }

    [Fact]
    public async Task Validate_WithInvalidNameLength_ReturnsFalse()
    {
        // Arrange
        var validator = new CreatePlatformDtoValidator(_mockRepository.Object);
        var dto = new CreatePlatformDto
        {
            Name = "aaa", // Name length less than the minimum length (5)
            MaintainerId = 1
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CreatePlatformDto.Name));
    }

    [Fact]
    public async Task Validate_WithInvalidMaintainerId_ReturnsFalse()
    {
        // Arrange
        var validator = new CreatePlatformDtoValidator(_mockRepository.Object);
        var dto = new CreatePlatformDto
        {
            Name = "ValidName",
            MaintainerId = 999 // Invalid MaintainerId
        };

        _mockRepository.Setup(r => r.Exists(dto.MaintainerId)).ReturnsAsync(false);

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CreatePlatformDto.MaintainerId));
    }
}
