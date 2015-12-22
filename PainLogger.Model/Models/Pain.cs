using PainLogger.Model.Enums;

namespace PainLogger.Model.Models
{
    public class Pain
    {
        public BodyPart BodyPart { get; set; }
        public BodySide BodySide { get; set; }
        public PainType PainType { get; set; }
    }
}