using System.CodeDom;
using FluentValidation;
using FluentyValidation.Models;
using StructureMap;

namespace FluentyValidation.Infrastructure
{
    public class ValidatorRegistry : Registry
    {
        public ValidatorRegistry()
        {
            AssemblyScanner.FindValidatorsInAssemblyContaining<CustomerValidator>()
                .ForEach(result =>
                {
                    For(result.InterfaceType).Singleton().Use(result.ValidatorType);
                });
        }
    }
}