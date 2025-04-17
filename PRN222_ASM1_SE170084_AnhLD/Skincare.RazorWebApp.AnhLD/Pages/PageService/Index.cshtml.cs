using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Skincare.Repositories.Models;

namespace Skincare.RazorWebApp.AnhLD.Pages.PageService
{
    public class IndexModel  : PageModel
    {
        private readonly Skincare.Repositories.Models.SP25_PRN222_W3_PRJ_G1_SkinCareBookingServiceContext _context;

        public IndexModel()
        {
            _context ??= new SP25_PRN222_W3_PRJ_G1_SkinCareBookingServiceContext();
        }

        public IList<ServiceProviderInfo> ServiceProviderInfo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ServiceProviderInfo = await _context.ServiceProviderInfos.ToListAsync();
        }
    }
}
