using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Data;
using WEBWORK.DATA.Models;
using WEBWORK.DATA.Models.BindingTarget;
using WEBWORK.WEB3.Repositories;
using WEBWORK.WEB3.Repositories.IRepositories;
using WEBWORK.WEB3.Models;
using WEBWORK.WEB3.Infrastructure.Security;

namespace WEBWORK.WEB3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UsersController(UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            this.userManager = _userManager;
            this.roleManager = roleManager;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> createUser([FromBody] UserData udata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityUser user = await userManager.FindByNameAsync(udata.Username);
           
            if (user == null)
            {
                var identityUser = new IdentityUser(udata.Username);

                IdentityResult result = await this.userManager.CreateAsync(identityUser,udata.Password);
            }

            return Ok();
        }

        [HttpPost("createRole")]
        public async Task<IActionResult> createRole([FromBody] string roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                IdentityRole role = await this.roleManager.FindByNameAsync(roles);
                if (role == null)
                {
                    IdentityResult result = await this.roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("Error in creating role "+ roles);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
               
            }
        }

    }
}
