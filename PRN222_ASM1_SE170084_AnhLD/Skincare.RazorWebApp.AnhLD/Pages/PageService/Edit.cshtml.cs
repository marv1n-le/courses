using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skincare.Repositories.Models;
using Skincare.Services.Interface;

namespace Skincare.RazorWebApp.AnhLD.Pages.PageService
{
    public class EditModel : PageModel
    {
        private readonly IServiceProviderInfoService _serviceProviderInfoService;

        public EditModel(IServiceProviderInfoService serviceProviderInfoService)
        {
            _serviceProviderInfoService = serviceProviderInfoService;
        }

        [BindProperty]
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
            ServiceProviderInfo = serviceproviderinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_serviceProviderInfoService.Attach(ServiceProviderInfo).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ServiceProviderInfoExists(ServiceProviderInfo.ProviderId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            var result = await _serviceProviderInfoService.UpdateAsync(ServiceProviderInfo);

            if (result > 0)
            {
                return RedirectToPage("./Index");
            }
            return Page();

        }

        //private bool ServiceProviderInfoExists(int id)
        //{
        //    return _serviceProviderInfoService.Any(e => e.ProviderId == id);
        //}
    }
}
