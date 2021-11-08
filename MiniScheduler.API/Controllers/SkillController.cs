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
            var skill = await _SkillRepository.Get(id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }

        // PUT: api/Skill/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Skill>> PutSkill(Skill skill)
        {
            skill.Updated = DateTime.UtcNow;
            await _SkillRepository.Update(skill);

            return skill;
        }

        // POST: api/Skill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill(Skill skill)
        {
            skill.Created = DateTime.UtcNow;
            await _SkillRepository.Add(skill);

            return CreatedAtAction("GetSkill", new { id = skill.Id }, skill);
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
