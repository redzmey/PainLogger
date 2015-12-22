using System;
using PainLogger.Model.Interfaces;

namespace PainLogger.Model.Models
{
    public class Medicine : IElement
    {
        public double Dosage { get; set; }

        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}