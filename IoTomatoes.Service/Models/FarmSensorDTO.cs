﻿using System;
namespace IoTomatoes.Application.Models
{
    public class FarmSensorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int FarmId { get; set; }
        public int SensorId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
