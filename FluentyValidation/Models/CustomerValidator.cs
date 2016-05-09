﻿using FluentValidation;

namespace FluentyValidation.Models
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(m => m.CustomerName).NotNull();
            RuleFor(m => m.CustomerName).Length(5, 25);
            When(c=>c.IsPreferred, () =>
            {
                RuleFor(c => c.Discount).GreaterThan(0);
            });
        }
    }
}