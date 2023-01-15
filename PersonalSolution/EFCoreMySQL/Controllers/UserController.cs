using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDBContext myDbContext;

        public UserController(MyDBContext context, IConfiguration configuration)
        {
            myDbContext = context;

            // Can get data from appsettings.json
            _ = configuration["ConnectionStrings:DefaultConnection"];
            _ = configuration["AllowedHosts"];
            _ = configuration["Logging:LogLevel:Microsoft"];
        }

        [HttpGet]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser()
        {
            try
            {
                myDbContext.Users.Add(new User
                {
                    FirstName = "dafdd",
                    UserGroupId = 1,
                    LastName = "fgffgfghd",
                    CreationDateTime = DateTime.Now
                });
                await myDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                // first table, second table
                // myDbContext.Users.Where(x => x.UserGroupId == 2).Join( if we need to filter
                // on firstKey = secondKey
                // write them in ()
                // get necessary fields

                var data = myDbContext.Users.Join(
                           myDbContext.UserGroups,
                           users => users.UserGroupId,
                           uGroups => uGroups.Id,
                           (users, uGroups) => new
                           {
                               UFirstName = users.FirstName,
                               ULastName = users.LastName,
                               UserGroupID = users.Id,
                               UserGroupName = uGroups.Name,
                               uGroups.CreationDateTime
                           }).ToList();

                var count = data.Count;

                return Ok(myDbContext.Users.Where(x => x.CreationDateTime != default)
                                           .Select(y => new
                                           {
                                               id = y.Id,
                                               firstName = y.FirstName
                                           }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}