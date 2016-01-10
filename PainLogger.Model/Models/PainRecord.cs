using System;
using PainLogger.Model.Interfaces;

namespace PainLogger.Model.Models
{
    public class PainRecord : IElement, ITakenTime
    {
        public PainRecord()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public double LastedHours => (TimeEnded - TakenTime).TotalHours;
        public int Level { get; set; }

        public Pain Pain { get; set; }
        public DateTime TakenTime { get; set; }
        public DateTime TimeEnded { get; set; }
    }
}