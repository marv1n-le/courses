using Microsoft.AspNetCore.Mvc;
using Skincare.Services.Interface;

namespace Skincare.MVCWebApp.AnhLD.Controllers
{
    public class ServiceProviderInfoController : Controller
    {
        private readonly IServiceProviders _serviceProviders;

        public ServiceProviderInfoController(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        public IActionResult Index()
        {
            var serviceProviders = _serviceProviders.ServiceProviderInfoService.GetAllServiceProvidersAsync();
            return View(serviceProviders);
        }

        public async Task<IActionResult> Details(int id)
        {
            var serviceProvider = await _serviceProviders.ServiceProviderInfoService.GetServiceProviderByIdAsync(id);
            if (serviceProvider == null)
            {
                return NotFound();
            }
            return View(serviceProvider);
        }
    }
}
