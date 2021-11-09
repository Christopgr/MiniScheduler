using Microsoft.AspNetCore.Mvc;
using MiniScheduler.DataAccessLayer.Repositories;
using MiniScheduler.Domain.Filters;
using MiniScheduler.Domain.Models;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace MiniScheduler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployController : ControllerBase
    {
        private readonly IEmployRepository _employRepository;

        public EmployController(IEmployRepository employRepository)
        {
            _employRepository = employRepository;
        }

        // GET: api/Employ
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employ>>> GetEmploy([FromQuery] EmployFilter employFilter)
        {
            var employees = await _employRepository.GetAll();
            var filterQuery = JObject.Parse(employFilter.Filter).GetValue("q");
            return filterQuery != null
                ? employees.Where(x => x.Name.ToLowerInvariant().Contains(filterQuery.ToString().ToLowerInvariant()) || x.Surname.ToLowerInvariant().Contains(filterQuery.ToString().ToLowerInvariant())).ToList()
                : employees;
        }

        // GET: api/Employ/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employ>> GetEmploy(int id)
        {
            var employ = await _employRepository.Get(id);

            if (employ == null)
            {
                return NotFound();
            }

            return employ;
        }

        // PUT: api/Employ/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employ>> PutEmploy(Employ employ)
        {
            await _employRepository.Update(employ);

            return employ;
        }

        // POST: api/Employ
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employ>> PostEmploy(Employ employ)
        {
            await _employRepository.Add(employ);

            return CreatedAtAction("GetEmploy", new { id = employ.Id }, employ);
        }

        // DELETE: api/Employ/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploy(int id)
        {
            await _employRepository.Delete(id);

            return NoContent();
        }
    }
}
