using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace VKmfSoft_EHealth_API.Models.Domain.Invoice
{
    public class InvoiceDetailLine
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }

    }
}
