using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;

namespace FluentyValidation.Models
{
    public class Customer : IAsyncRequest
    {
        public string CustomerName { get; set; }
        public bool IsPreferred { get; set; }
        public double Discount { get; set; }
    }


    public class AddCustomer : AsyncRequestHandler<Customer>
    {
        protected override async Task HandleCore(Customer message)
        {
            // Do Something to Save the customer

        }
    }
}