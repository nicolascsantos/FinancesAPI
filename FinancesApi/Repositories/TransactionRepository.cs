using FinancesApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesApi.Repositories
{
    public class TransactionRepository
    {
        private readonly ContextoDB _context;

        public TransactionRepository(ContextoDB contexto)
        {
            _context = contexto;
        }
    }
}
