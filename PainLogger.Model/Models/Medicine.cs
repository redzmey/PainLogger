using System;
using PainLogger.Model.Interfaces;

namespace PainLogger.Model.Models
{
    public class Medicine : IElement
    {
        public Medicine()
        {
            Id = Guid.NewGuid();
            Name = "";
            Dosage = 0;
        }

        public double Dosage { get; set; }
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}