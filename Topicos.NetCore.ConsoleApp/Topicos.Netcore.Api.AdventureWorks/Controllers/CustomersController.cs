using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Topicos.Netcore.NorthWnd.Model.MyModels;

namespace Topicos.Netcore.Api.AdventureWorks.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AdventureWorksLT2019Context _context;
        private readonly IMapper _mapper;

        public CustomersController(IMapper mapper)
        {
            _mapper = mapper;
            _context = new AdventureWorksLT2019Context();
        }

        //public CustomersController(AdventureWorksLT2019Context context)
        //{
        //    _context = context;
        //}

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyDtoModels.DtoCustomer>>> GetCustomers(int pageSize = 10, int pageNumber = 1)
        {
            var customerBD = (await _context.Customers.Include(c => c.CustomerAddresses).ThenInclude(a => a.Address).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync());
            var customerResultante = _mapper.Map<List<MyDtoModels.DtoCustomer>>(customerBD);

            return customerResultante;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyDtoModels.DtoCustomer>> GetCustomer(int id)
        {
            var customerBD = (await _context.Customers.Include(c => c.CustomerAddresses).ThenInclude(a => a.Address).Where(c => c.CustomerId == id).ToListAsync()).FirstOrDefault();
            //var customer = await _context.Customers.FindAsync (id);

            if (customerBD == null)
            {
                return NotFound();
            }
            var customerResultante = _mapper.Map<MyDtoModels.DtoCustomer>(customerBD);

            return customerResultante;
        }



        #region TareaII_Pagination_API
        // Pagination 
        public class PaginationFilter
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public PaginationFilter()
            {
                this.PageNumber = 0;
                this.PageSize = 0;
            }
            public PaginationFilter(int pageNumber, int pageSize)
            {
                this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
                this.PageSize = pageSize > 10 ? 10 : pageSize;
            }
        }

        // GET: api/Customer/PagedQuery2/1?PageNumber=1&PageSize=3
        [HttpGet("PagedQuery2/{id}")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var response = await _context.Customers.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToListAsync();
            return Ok(response);
        }
        #endregion


        #region PaginationSQL
        // GET: api/Customer/PagedQuerySQL/1?PageNumber=1&PageSize=3
        [HttpGet("PagedQuerySQL/{id}")]
        public async Task<IActionResult> GetAll2([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pageNumber = new SqlParameter("@pageNumber", validFilter.PageNumber);
            var pageSize = new SqlParameter("@pageSize", validFilter.PageSize);

            var users = _context.Customers
                        .FromSqlRaw("exec [dbo].[sp_GetUsers] @pageSize, @pageNumber", pageSize, pageNumber)
                        .ToList();

            return Ok(users);
        }
        #endregion





        // GET: api/Customers/PagedQuery/5?HelloWorld=1234
        [HttpGet("PagedQuery/{id}")]
        public async Task<ActionResult<MyDtoModels.DtoCustomer>> GetCustomer(int id, int HelloWorld)
        {
            var customerBD = (await _context.Customers.Include(c => c.CustomerAddresses).ThenInclude(a => a.Address).Where(c => c.CustomerId == id).ToListAsync()).FirstOrDefault();
            //var customer = await _context.Customers.FindAsync (id);

            if (customerBD == null)
            {
                return NotFound();
            }
            var customerResultante = _mapper.Map<Customer, MyDtoModels.DtoCustomer>(customerBD);

            return customerResultante;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
