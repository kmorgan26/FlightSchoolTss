﻿namespace FlightSchoolTss.Data.DTOs.Lot;
public class LotDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int PlatformId { get; set; }
    public int MaintainableId { get; set; }
}