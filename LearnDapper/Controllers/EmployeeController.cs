using Dapper;
using LearnDapper.Models;
using LearnDapper.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LearnDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo employeeRepo;

        public  EmployeeController(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo= employeeRepo;
        }
        [HttpGet("GetAll")]
        public async  Task<IActionResult> GetAll()
        {
            var emplist = await employeeRepo.GetAll();
            if (emplist != null)
            {
            return Ok(emplist);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string Name)
        {
            var emplist = await employeeRepo.GetByName(Name);
            if (emplist != null)
            {
                return Ok(emplist);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee emp)
        {
           var res = await employeeRepo.AddEmployee(emp);
            return Ok(res);

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string Name)
        {
            var res = await employeeRepo.Remove(Name);
            return Ok();
        }
    }
}
