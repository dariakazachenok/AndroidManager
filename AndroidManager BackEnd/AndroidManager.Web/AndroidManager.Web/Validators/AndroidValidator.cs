using AndroidManager.WebApi;
using FluentValidation;

namespace AndroidManager.Web.Validators
{
    public class AndroidValidator : AbstractValidator<AndroidBindModel>
    {
        public AndroidValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(5, 24);
            RuleFor(x => x.Avatar).NotEmpty();
        }
    }
}
