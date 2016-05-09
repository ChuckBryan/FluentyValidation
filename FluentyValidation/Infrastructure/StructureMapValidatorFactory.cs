﻿using System;
using FluentValidation;
using Heroic.Web.IoC;

namespace FluentyValidation.Infrastructure
{
    public class StructureMapValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            return IoC.Container.TryGetInstance(validatorType) as IValidator;
        }
    }

}