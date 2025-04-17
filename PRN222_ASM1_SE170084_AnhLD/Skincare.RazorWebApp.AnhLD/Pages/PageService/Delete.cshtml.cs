using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Skincare.Repositories.Models;
using Skincare.Services.Interface;
using Skincare.Services.Service;

namespace Skincare.RazorWebApp.AnhLD.Pages.PageService
{
    public class DeleteModel : PageModel
    {
        private readonly IServiceProviderInfoService _serviceProviderInfoService;

        public DeleteModel(IServiceProviderInfoService serviceProviderInfoService)
        {
            _serviceProviderInfoService = serviceProviderInfoService;
        }

        [BindProperty]
        public ServiceProviderInfo ServiceProviderInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceproviderinfo = await _serviceProviderInfoService.GetServiceProviderByIdAsync(id.Value);

            if (serviceproviderinfo == null)
            {
                return NotFound();
            }
            else
            {
                ServiceProviderInfo = serviceproviderinfo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _serviceProviderInfoService.DeleteAsync(id.Value);
            if (result)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
