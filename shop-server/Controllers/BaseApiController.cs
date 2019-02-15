using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using shop_server.Data;

namespace shop_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        #region Shred properties
        protected ApplicationDbContext DbContext { get; private set; }
        protected UserManager<IdentityUser> UserManager { get; private set; }
        protected RoleManager<IdentityRole> RoleManager { get; private set; }
        protected IConfiguration Configuration { get; private set; }
        #endregion

        #region  Constructor
        public BaseApiController(ApplicationDbContext context,
                                 UserManager<IdentityUser> userManager, 
                                 RoleManager<IdentityRole> roleManager,
                                 IConfiguration configuration)
        {
            DbContext = context;
            UserManager = userManager;
            RoleManager = roleManager;
            Configuration = configuration;
        }
        #endregion 
    }
}