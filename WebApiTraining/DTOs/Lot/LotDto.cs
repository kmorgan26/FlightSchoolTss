﻿using WebApiTraining.DTOs.Platform;

namespace WebApiTraining.DTOs.Lot;

public class LotDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PlatformId { get; set; }

    public virtual PlatformDto Platform { get; set; }
}