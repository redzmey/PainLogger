using System;

namespace PainLogger.Model.Models
{
    public class Medication
    {
        public Medicine Medicine { get; set; }
        public DateTime TakenTime { get; set; }

        public double DosageCount { get; set; }
        public double TotalDosage => DosageCount*Medicine.Dosage;
    }
}