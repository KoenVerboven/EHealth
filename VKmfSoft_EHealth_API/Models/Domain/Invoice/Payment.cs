using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Invoice
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public byte PaymentMethodId { get; set; } // todo cash, kreditcard, ...
        public int? TransactionId { get; set; }
    }
}
