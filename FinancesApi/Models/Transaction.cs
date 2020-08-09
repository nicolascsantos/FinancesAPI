using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinancesApi.Models
{
    public class Transaction
    {
        [Key]
        public int transaction_id { get; set; }

        [Required]
        public string transaction_type { get; set; }

        [Required]
        public double transaction_value { get; set; }

        [Required]
        public DateTime created_at { get; set; }
    }
}
