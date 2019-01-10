﻿using System;
using System.Collections.Generic;

namespace IoTomatoes.Domain.Models
{
    public partial class FarmSensor
    {
        public FarmSensor()
        {
            FarmSensorMeasurement = new HashSet<FarmSensorMeasurement>();
        }

        public int Id { get; set; }
        public int? FarmId { get; set; }
        public int? SensorId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Farm Farm { get; set; }
        public virtual Sensor Sensor { get; set; }
        public virtual ICollection<FarmSensorMeasurement> FarmSensorMeasurements { get; set; }
    }
}