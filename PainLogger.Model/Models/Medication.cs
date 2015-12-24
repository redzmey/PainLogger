using System;
using PainLogger.Model.Interfaces;

namespace PainLogger.Model.Models
{
    public class Medication : IElement, ITakenTime
    {
        public Medication()
        {
            Id = Guid.NewGuid();
        }

        public double DosageCount { get; set; }
        public Guid Id { get; set; }
        public Medicine Medicine { get; set; }
        public DateTime TakenTime { get; set; }
        public double TotalDosage => DosageCount*Medicine.Dosage;
    }
}