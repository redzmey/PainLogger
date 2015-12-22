using System;
using PainLogger.Model.Interfaces;

namespace PainLogger.Model.Models
{
    public class Medication: IElement
    {
        public Guid Id { get; set; }
        public Medicine Medicine { get; set; }
        public DateTime TakenTime { get; set; }

        public double DosageCount { get; set; }
        public double TotalDosage => DosageCount*Medicine.Dosage;
    }
}