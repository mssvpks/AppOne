using Microsoft.EntityFrameworkCore;

namespace AppOne.Models
{
    public class Finance
    {
        public int Id { get; set; }
        public string? TransactionName { get; set; }
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
