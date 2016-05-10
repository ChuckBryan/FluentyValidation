using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Mvc;
using FluentValidation.Validators;

namespace FluentyValidation.Models
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(m => m.CustomerName).Length(5, 25).NotNull();
            RuleFor(m => m.Email)
                .EmailAddress()
                .NotNull()
                .SetValidator(new NotSwampyValidator());
        }
    }

    public class NotSwampyValidator : PropertyValidator
    {

        public NotSwampyValidator():base("Sorry, you're not a Swampy!")
        {
            
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            string emailAddress = context.PropertyDescription as string;

            return emailAddress.StartsWith("Swampy");
        }
    }

    public class NotSwampyPropertyValidator : FluentValidationPropertyValidator
    {
        public NotSwampyPropertyValidator(ModelMetadata metadata, ControllerContext controllerContext, 
            PropertyRule rule, IPropertyValidator validator) : base(metadata, controllerContext, rule, validator)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            if(!this.ShouldGenerateClientSideRules())
                yield break;

            var formatter = new MessageFormatter().AppendPropertyName(Rule.PropertyName);
            string message = formatter.BuildMessage(Validator.ErrorMessageSource.GetString());

            var rule = new ModelClientValidationRule()
            {
                ValidationType = "remote",
                ErrorMessage = message
            };

            rule.ValidationParameters.Add("url", "/home/isaswampy");


            yield return rule;
        }
    }
}