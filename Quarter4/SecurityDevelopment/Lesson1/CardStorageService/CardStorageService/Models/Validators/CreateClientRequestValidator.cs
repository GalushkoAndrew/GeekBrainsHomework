using CardStorageService.Models.Requests;
using FluentValidation;

namespace CardStorageService.Models.Validators
{
    public class CreateClientRequestValidator : AbstractValidator<CreateClientRequest>
    {
        public CreateClientRequestValidator()
        {
            RuleFor(x => x.Firstname)
                .MinimumLength(1);
            RuleFor(x => x.Surname)
                .MinimumLength(1);
        }
    }
}
