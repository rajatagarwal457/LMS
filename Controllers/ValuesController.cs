using LMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreEg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly LmsContext _db;

        public ValuesController(LmsContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCustomers()
        {
            return Ok(_db.EmployeeMasters);
        }
    }

    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LmsContext _db;

        public LoginController(LmsContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> Login(String uname, String pw)
        {
            FormattableString q = $"select * from employee_credentials where employee_id = {uname} and employee_password = {pw};";
            List<EmployeeCredential>? res = _db.EmployeeCredentials.FromSql(q).ToList();
            if(res.Count() == 0)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(res.First().EmployeeRole);
            }
            
        }
    }
}