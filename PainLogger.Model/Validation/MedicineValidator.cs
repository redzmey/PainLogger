using FluentValidation;
using PainLogger.Model.Models;

namespace PainLogger.Model.Validation
{
    public class MedicineValidator : AbstractValidator<Medicine>
    {
        public MedicineValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Dosage).GreaterThanOrEqualTo(0).NotNull();
        }
    }
}