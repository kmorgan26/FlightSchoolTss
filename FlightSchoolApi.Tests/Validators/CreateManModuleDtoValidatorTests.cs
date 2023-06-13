using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.DTOs.ManModule;
using FlightSchoolTss.Data.Validators.ManModule;
using Moq;

namespace FlightSchoolTss.Tests.Validators;
public class CreateManModuleDtoValidatorTests
{
    private readonly Mock<IManModuleRepository> _mockRepository;

    public CreateManModuleDtoValidatorTests()
    {
        _mockRepository = new Mock<IManModuleRepository>();
    }

    //[Fact]
    //public async Task Validate_WithValidDto_ReturnsTrue()
    //{
    //    // Arrange
    //    var validator = new CreateManModuleDtoValidator(_mockRepository.Object);
    //    var dto = new CreateManModuleDto
    //    {
    //        Name = "Valid Name",
    //        LotId = 1,
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
        var validator = new CreateManModuleDtoValidator(_mockRepository.Object);
        var dto = new CreateManModuleDto
        {
            Name = "", // Empty name
            LotId = 1
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CreateManModuleDto.Name));
    }

    [Fact]
    public async Task Validate_WithInvalidNameLength_ReturnsFalse()
    {
        // Arrange
        var validator = new CreateManModuleDtoValidator(_mockRepository.Object);
        var dto = new CreateManModuleDto
        {
            Name = "aaa", // Name length less than the minimum length (5)
            LotId = 1
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CreateManModuleDto.Name));
    }

    [Fact]
    public async Task Validate_WithInvalidLotId_ReturnsFalse()
    {
        // Arrange
        var validator = new CreateManModuleDtoValidator(_mockRepository.Object);
        var dto = new CreateManModuleDto
        {
            Name = "ValidName",
            LotId = 999 // Invalid LotId
        };

        _mockRepository.Setup(r => r.Exists(dto.LotId)).ReturnsAsync(false);

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CreateManModuleDto.LotId));
    }
}
