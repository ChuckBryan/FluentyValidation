using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;
using FluentyValidation.Infrastructure;
using FluentyValidation.Models;
using Heroic.Web.IoC;

namespace FluentyValidation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            

            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new StructureMapValidatorFactory();
                //provider.AddImplicitRequiredValidator = false;

                provider.Add(typeof(NotSwampyValidator), (metadata, context, description, validator) =>
                    new NotSwampyPropertyValidator(metadata, context, description, validator));

                //ModelValidatorProviders.Providers.Add(provider);
            });

            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;

            // cfg.For<IValidatorFactory>().Use<StructureMapValidatorFactory>();
            // cfg.For<ModelValidatorProvider>().Use<FluentValidationModelValidatorProvider>();

        }
    }
}
