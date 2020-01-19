using System.Linq;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestApp.Models;
using TestApp.ViewModels;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [FormatFilter]
    public class UsersController : ControllerBase
    {
        UserService _userService;
        UserManager<ApplicationUser> _userManager;

        public UsersController(UserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var domainUsers = await _userService.GetUsers();
            var userViewModels = domainUsers.Select(u => new UserViewModel() { Id = u.Id, Name = u.Name, UserName = u.UserName }).ToList(); //без email
            if (userViewModels.Any())
                return Ok(userViewModels);
            else
                return new NotFoundObjectResult("Not found");
        }

        [Authorize]
        [HttpGet("{id}")]
        //[HttpGet("{id}.{format?}")]
        public async Task<IActionResult> GetById(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var user = await _userService.GetUserById(id);
            if (user == null)
                return new NotFoundObjectResult("Not found");
            if (user?.Id == currentUser?.UserId)
                return Ok(user);
            else
                return Forbid();
        }
    }
}