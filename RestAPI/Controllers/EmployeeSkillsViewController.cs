using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    public class EmployeeSkillsViewController : Controller
    {
        private readonly EmployeeSkillController _employeeSkillController;

        public EmployeeSkillsViewController(EmployeeSkillController employeeSkillController)
        {
            _employeeSkillController = employeeSkillController;
        }
        public async Task<IActionResult> Employee()
        {
            var result = await _employeeSkillController.GetEmployee();
            return View(result);

        }

        public async Task<IActionResult> Skills()
        {
            var result = await _employeeSkillController.GetSkills();
            return View(result);
        }

    }
}
