using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Skincare.Repositories.Models;
using Skincare.Services.Interface;

namespace Skincare.RazorWebApp.AnhLD.Pages.PageService
{
    public class DetailsModel : PageModel
    {
        private readonly IServiceProviderInfoService _serviceProviderInfoService;

        public DetailsModel(IServiceProviderInfoService serviceProviderInfoService)
        {
            _serviceProviderInfoService = serviceProviderInfoService;
        }

        public ServiceProviderInfo ServiceProviderInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceproviderinfo = await _serviceProviderInfoService.GetServiceProviderByIdAsync(id);
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
    }
}
