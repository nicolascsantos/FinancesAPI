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
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ContextoDB _context;

        public TransactionController(ContextoDB contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var transacoes = _context.Transactions.ToList();

            if (transacoes.Count == 0)
            {
                return NotFound();
            }

            return new JsonResult(transacoes);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Transaction transaction)
        {
            transaction.created_at = DateTime.Now;

            if (transaction.transaction_type != "income" && transaction.transaction_type != "outcome")
            {
                return BadRequest();
            }

            try
            {
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
                throw;
            }

            return new JsonResult(transaction);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var registroDesejado = await _context.Transactions.FindAsync(id);

            if (registroDesejado == null)
            {
                return BadRequest();
            }

            _context.Transactions.Remove(registroDesejado);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
