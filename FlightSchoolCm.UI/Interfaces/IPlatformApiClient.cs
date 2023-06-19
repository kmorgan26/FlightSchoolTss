using FlightSchoolTss.DTOs.Platform;

namespace FlightSchoolCm.UI.Interfaces;

public interface IPlatformApiClient
{
    Task<List<PlatformDetailsDto>> GetPlatformDetailsAsync();
}
