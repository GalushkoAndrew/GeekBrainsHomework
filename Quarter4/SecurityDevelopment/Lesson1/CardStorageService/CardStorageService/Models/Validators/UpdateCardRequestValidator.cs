using CardStorageService.Models.Requests;
using FluentValidation;
using System;

namespace CardStorageService.Models.Validators
{
    public class UpdateCardRequestValidator : AbstractValidator<UpdateCardRequest>
    {
        public UpdateCardRequestValidator()
        {
            RuleFor(x => x.ClientId)
                .GreaterThanOrEqualTo(1);
            RuleFor(x => x.CardNo)
                .Length(16);
            RuleFor(x => x.ExpDate)
                .GreaterThan(DateTime.Now);
            RuleFor(x => x.Name)
                .MinimumLength(5);
            RuleFor(x => x.CVV2)
                .Length(3);
            RuleFor(x => x.CardId)
                .Must(IsGuid)
                .WithMessage("Не Guid");
        }

        private bool IsGuid(string value)
        {
            return Guid.TryParse(value, out var _);
        }
    }
}
