using AndroidManager.WebApi;
using FluentValidation;

namespace AndroidManager.Web.Validators
{
    public class AndroidValidator : AbstractValidator<AndroidBindModel>
    {
        public AndroidValidator()
        {
            RuleFor(x => x.AndroidName).NotEmpty();
            RuleFor(x => x.AndroidName).Length(5, 24);
        }
    }
}
