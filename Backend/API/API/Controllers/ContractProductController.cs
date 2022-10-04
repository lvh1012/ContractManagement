using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DataContext;
using API.Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractProductController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public ContractProductController(ApplicationDataContext context)
        {
            _context = context;
        }

        // GET: api/ContractProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractProduct>>> GetContractProducts()
        {
            return await _context.ContractProducts.ToListAsync();
        }

        // GET: api/ContractProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContractProduct>> GetContractProduct(Guid id)
        {
            var contractProduct = await _context.ContractProducts.FindAsync(id);

            if (contractProduct == null)
            {
                return NotFound();
            }

            return contractProduct;
        }

        // PUT: api/ContractProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContractProduct(Guid id, ContractProduct contractProduct)
        {
            if (id != contractProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(contractProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContractProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContractProduct>> PostContractProduct(ContractProduct contractProduct)
        {
            _context.ContractProducts.Add(contractProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContractProduct", new { id = contractProduct.Id }, contractProduct);
        }

        // DELETE: api/ContractProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContractProduct(Guid id)
        {
            var contractProduct = await _context.ContractProducts.FindAsync(id);
            if (contractProduct == null)
            {
                return NotFound();
            }

            _context.ContractProducts.Remove(contractProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContractProductExists(Guid id)
        {
            return _context.ContractProducts.Any(e => e.Id == id);
        }
    }
}
