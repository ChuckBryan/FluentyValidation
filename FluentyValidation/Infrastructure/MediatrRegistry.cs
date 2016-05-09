using System.EnterpriseServices;
using FluentyValidation.Models;
using MediatR;
using StructureMap;

namespace FluentyValidation.Infrastructure
{
    public class MediatrRegistry : Registry
    {
        public MediatrRegistry()
        {
            Scan(s =>
            {

                s.AssemblyContainingType<IMediator>();
                s.AssemblyContainingType<MediatrRegistry>();
                s.AddAllTypesOf((typeof(IRequestHandler<,>)));
                s.AddAllTypesOf((typeof(INotificationHandler<>)));
                s.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
                s.AddAllTypesOf(typeof(IAsyncNotificationHandler<>));
                
                /*s.AddAllTypesOf(typeof(IValidator<>));*/
                s.WithDefaultConventions();
            });

            For(typeof (IAsyncRequestHandler<,>)).DecorateAllWith(typeof (ValidationHandler<,>));

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            For<IMediator>().Use<Mediator>();
        }
    }
}