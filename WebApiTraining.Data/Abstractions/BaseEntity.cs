﻿namespace WebApiTraining.Data.Abstractions
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}