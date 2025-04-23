using Microsoft.AspNetCore.Mvc;
using Skincare.Repositories.Models;
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

        public async Task<IActionResult> Index()
        {
            var serviceProviders = await _serviceProviders.ServiceProviderInfoService.GetAllServiceProvidersAsync();
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

        public async Task<IActionResult> Create()
        {
            var serviceProviders = await _serviceProviders.ServiceProviderInfoService.GetAllServiceProvidersAsync();

            int maxId = serviceProviders.Max(sp => sp.ProviderId);

            var newServiceProvider = new ServiceProviderInfo()
            {
                ProviderId = maxId + 1,
            };

            return View(newServiceProvider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceProviderInfo serviceProvider)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceProviders.ServiceProviderInfoService.CreateAsync(serviceProvider);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(serviceProvider);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serviceProvider = await _serviceProviders.ServiceProviderInfoService.GetServiceProviderByIdAsync(id);
            if (serviceProvider == null)
            {
                return NotFound();
            }
            return View(serviceProvider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceProviderInfo serviceProvider)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceProviders.ServiceProviderInfoService.UpdateAsync(serviceProvider);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(serviceProvider);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var serviceProvider = await _serviceProviders.ServiceProviderInfoService.GetServiceProviderByIdAsync(id);
            if (serviceProvider == null)
            {
                return NotFound();
            }
            return View(serviceProvider);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _serviceProviders.ServiceProviderInfoService.DeleteAsync(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Delete), new { id = id });

        }
    }
}
