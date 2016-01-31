using System;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Dosage")]
        public double Dosage { get; set; }
        public Guid Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}