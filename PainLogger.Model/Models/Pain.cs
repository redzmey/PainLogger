using System;
using PainLogger.Model.Enums;
using PainLogger.Model.Interfaces;

namespace PainLogger.Model.Models
{
    public class Pain : IElement
    {
        public Pain()
        {
            Id = Guid.NewGuid();
        }

        public BodyPart BodyPart { get; set; }
        public BodySide BodySide { get; set; }
        public Guid Id { get; set; }
        public PainType PainType { get; set; }
    }
}