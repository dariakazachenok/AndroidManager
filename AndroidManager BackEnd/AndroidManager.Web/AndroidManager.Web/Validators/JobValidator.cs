using AndroidManager.WebApi;
using FluentValidation;

namespace AndroidManager.Web.Validators
{
    public class JobValidator : AbstractValidator<JobBindModel>
    {
        public JobValidator()
        {
           RuleFor(x => x.JobName).NotEmpty();
           RuleFor(x => x.JobName).Length(2, 16); 
           RuleFor(x => x.Description).NotEmpty().MaximumLength(255);
        }
    }
}
