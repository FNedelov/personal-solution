using EFCoreMySQL.DBContexts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EFCoreMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly MyDBContext myDbContext;

        public UserGroupController(MyDBContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        [Route("GetUserGroup")]
        public IActionResult GetUserGroup()
        {
            try
            {
                return Ok(myDbContext.UserGroups);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }            
        }
    }
}