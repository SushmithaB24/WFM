using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSkillController : ControllerBase
    {
        private readonly RestAPIDBContext _context;

        public EmployeeSkillController(RestAPIDBContext context)
        {
            _context = context;
        }

        [HttpGet, Route("GetEmployee")]
        public async Task<ActionResult> GetEmployee()
        {
            var employees = await _context.Employees.Include(s => s.SkillMaps).ThenInclude(s => s.Skills).Select(x => new EmployeeModel
            {
                EmployeeId = x.EmployeeId,
                Email = x.Email,
                Name = x.Name,
                Manager = x.Manager,
                Status = x.LockStatus,
                WfmManager = x.WfmManager,
                Skills = x.SkillMaps.Select(y => y.Skills.Name).ToList()
            }).ToListAsync();

            return new OkObjectResult(employees);
        }
        [HttpGet, Route("GetSkills")]
        public async Task<ActionResult> GetSkills()
        {
            var Skills =  _context.Skills.Include(x => x.SkillMaps).ThenInclude(x => x.Skills).Select(x => new SkillsModel
            {
                skillid = x.Skillid,
                name = x.Name,
                Employees = x.SkillMaps.Select(y => y.Employee.Name).ToList()
            }).ToList();
            return new OkObjectResult(Skills);
            
        }

    }
}
