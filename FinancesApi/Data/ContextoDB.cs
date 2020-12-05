using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinancesApi.Models;

namespace FinancesApi.Data
{
    public class ContextoDB : IdentityDbContext
    {
        public ContextoDB(DbContextOptions options): base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
