﻿using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.DTOs.Maintainer;
public class CreateMaintainerDto : BaseDtoViewModel
{
    private int _id;
    public override int Id { get => Id = _id; set => _id = value; }
}