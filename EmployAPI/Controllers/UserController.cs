using EmployAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataDbContext _dataDbContext;

        public UserController(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var user = await _dataDbContext.Users.ToListAsync();

            return Ok(user);
        }
    }
}
