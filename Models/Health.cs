using Microsoft.EntityFrameworkCore;

namespace AppOne.Models
{
    public class Health
    {
       
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? issueName { get; set; }

        public string? Age { get; set; }

        public string? comment { get; set; }
    }
}
