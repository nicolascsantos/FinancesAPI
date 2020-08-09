using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinancesApi.Models;

namespace FinancesApi.Data
{
    public class ContextoDB : DbContext
    {
        public ContextoDB(DbContextOptions options): base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
