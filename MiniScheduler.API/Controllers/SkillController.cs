using Microsoft.AspNetCore.Mvc;
using MiniScheduler.DataAccessLayer.Repositories;
using MiniScheduler.Domain.Models;

namespace MiniScheduler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepository _SkillRepository;

        public SkillController(ISkillRepository SkillRepository)
        {
            _SkillRepository = SkillRepository;
        }

        // GET: api/Skill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkill()
        {
            return await _SkillRepository.GetAll();
        }

        // GET: api/Skill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            var Skill = await _SkillRepository.Get(id);

            if (Skill == null)
            {
                return NotFound();
            }

            return Skill;
        }

        // POST: api/Skill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill(Skill Skill)
        {
            await _SkillRepository.Add(Skill);

            return CreatedAtAction("GetSkill", new { id = Skill.Id }, Skill);
        }

        // DELETE: api/Skill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            await _SkillRepository.Delete(id);

            return NoContent();
        }
    }
}
