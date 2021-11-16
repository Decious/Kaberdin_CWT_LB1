using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaberdin_LB1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Message { get; set; }

        public void OnGet()
        {
            Message = "GET method (text/css)";
            Response.ContentType = "text/css";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Message = "POST method (text/plain)";
            Response.ContentType = "text/plain";

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPut()
        {
            Message = "PUT method (application/json)";
            Response.ContentType = "application/json";

            return RedirectToPage();
        }
    }
}
