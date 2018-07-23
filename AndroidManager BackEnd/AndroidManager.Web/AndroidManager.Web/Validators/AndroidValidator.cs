using AndroidManager.WebApi;
using FluentValidation;

namespace AndroidManager.Web.Validators
{
    public class AndroidValidator : AbstractValidator<AndroidBindModel>
    {
        public AndroidValidator()
        {
            RuleFor(x => x.AndroidName).NotEmpty().Length(5, 24);
            RuleFor(x => x.Skills).NotEmpty();
        }
    }
}
