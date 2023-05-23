using Moq;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Validators.Lot;
using FlightSchoolTss.DTOs.Lot;
using System.Threading.Tasks;

namespace FlightSchoolTss.Tests.Validators;
public class CreateLotDtoValidatorTests
{
    private readonly Mock<ILotRepository> _mockRepository;

    public CreateLotDtoValidatorTests()
    {
        _mockRepository = new Mock<ILotRepository>();
    }

    //[Fact]
    //public async Task Validate_WithValidDto_ReturnsTrue()
    //{
    //    // Arrange
    //    var validator = new CreateLotDtoValidator(_mockRepository.Object);
    //    var dto = new CreateLotDto
    //    {
    //        Name = "ValidName",
    //        PlatformId = 1
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
        var validator = new CreateLotDtoValidator(_mockRepository.Object);
        var dto = new CreateLotDto
        {
            Name = "", // Empty name
            PlatformId = 1
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == "Name");
    }

    [Fact]
    public async Task Validate_WithInvalidNameLength_ReturnsFalse()
    {
        // Arrange
        var validator = new CreateLotDtoValidator(_mockRepository.Object);
        var dto = new CreateLotDto
        {
            Name = "aaa", // Name length less than the minimum length (5)
            PlatformId = 1
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == "Name");
    }

    [Fact]
    public async Task Validate_WithMissingPlatformId_ReturnsFalse()
    {
        // Arrange
        var validator = new CreateLotDtoValidator(_mockRepository.Object);
        var dto = new CreateLotDto
        {
            Name = "ValidName",
            PlatformId = 0 // Invalid platform ID (assuming 0 is invalid)
        };

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == "PlatformId");
    }

    [Fact]
    public async Task Validate_WithNonExistingPlatformId_ReturnsFalse()
    {
        // Arrange
        var validator = new CreateLotDtoValidator(_mockRepository.Object);
        var dto = new CreateLotDto
        {
            Name = "ValidName",
            PlatformId = 1
        };
        _mockRepository.Setup(r => r.Exists(dto.PlatformId)).ReturnsAsync(false);

        // Act
        var result = await validator.ValidateAsync(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == "PlatformId");
    }
}
