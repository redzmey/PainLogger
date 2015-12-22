using System;
using PainLogger.Model.Interfaces;

namespace PainLogger.Model.Models
{
    public class PainRecord : IElement
    {
        public double LastedHours => (TimeEnded - TimeStarted).TotalHours;
        public int Level { get; set; }

        public Pain Pain { get; set; }
        public DateTime TimeEnded { get; set; }
        public DateTime TimeStarted { get; set; }
        public Guid Id { get; set; }
    }
}