using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Skincare.Repositories.Models;
using Skincare.Services.Interface;

namespace Skincare.RazorWebApp.AnhLD.Pages.PageService
{
    public class CreateModel : PageModel
    {
        private readonly IServiceProviderInfoService _serviceProviderInfoService;
        private readonly ICustomerServiceHistoryService _customerServiceHistoryService;

        public CreateModel(IServiceProviderInfoService serviceProviderInfoService, ICustomerServiceHistoryService customerServiceHistoryService)
        {
            _serviceProviderInfoService = serviceProviderInfoService;
            _customerServiceHistoryService = customerServiceHistoryService;
        }

        public async Task<IActionResult> OnGet()
        {
            var _customerServiceHistory = await _customerServiceHistoryService.GetAllCustomerServiceHistoriesAsync();
            
            ViewData["CustomerName"] = new SelectList(_customerServiceHistory, "CustomerName", "CustomerName");
            return Page();
        }

        [BindProperty]
        public ServiceProviderInfo ServiceProviderInfo { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Trả về trang hiện tại và giữ lại thông tin đã nhập
                return Page();
            }

            var result = await _serviceProviderInfoService.CreateAsync(ServiceProviderInfo);
            if (result > 0)
            {
                return RedirectToPage("./Index");
            }

            // Nếu có lỗi, trả về lại trang và giữ lại thông tin đã nhập
            return Page();
        }
    }
}
