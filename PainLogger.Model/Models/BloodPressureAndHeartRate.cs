using System;
using PainLogger.Model.Interfaces;

namespace PainLogger.Model.Models
{
    public class BloodPressureAndHeartRate : IElement, ITakenTime
    {
        public BloodPressureAndHeartRate()
        {
            Id = new Guid();
        }

        public int HeartRate { get; set; }
        public int HighPressure { get; set; }
        public Guid Id { get; set; }
        public int LowerPressure { get; set; }
        public DateTime TakenTime { get; set; }
    }
}