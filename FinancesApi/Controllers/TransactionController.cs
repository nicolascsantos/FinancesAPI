using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinancesApi.Data;
using FinancesApi.Models;

namespace FinancesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ContextoDB _context; 

        public TransactionController(ContextoDB context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var transaction = _context.Transactions.ToList();

            if (transaction.Count == 0)
            {
                return NotFound();
            }

            return new JsonResult(transaction);
        }
    }
}
