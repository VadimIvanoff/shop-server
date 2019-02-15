using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace shop_server.Pages.Main
{
    [Authorize]
    public class MainModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}