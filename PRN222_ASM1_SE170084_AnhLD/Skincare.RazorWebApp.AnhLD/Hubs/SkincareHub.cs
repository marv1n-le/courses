using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Skincare.Repositories.Models;
using Skincare.Services.Interface;

namespace Skincare.RazorWebApp.AnhLD.Hubs
{
    public class SkincareHub : Hub
    {
        private readonly IServiceProviderInfoService _serviceProviderInfoService;
        private readonly ICustomerServiceHistoryService _customerServiceHistoryService;

        public SkincareHub(IServiceProviderInfoService serviceProviderInfoService, ICustomerServiceHistoryService customerServiceHistoryService)
        {
            _serviceProviderInfoService = serviceProviderInfoService;
            _customerServiceHistoryService = customerServiceHistoryService;
        }
        public async Task HubDeleteServiceProviderInfo(int id)
        {
            await Clients.All.SendAsync("Receiver_DeleteServiceProvider", id);

            await _serviceProviderInfoService.DeleteAsync(id);
        }

        public async Task HubCreateServiceProviderInfo(string serviceProvider)
        {
            var item = JsonConvert.DeserializeObject<ServiceProviderInfo>(serviceProvider);

            //send this object to all clients
            await Clients.All.SendAsync("Receiver_CreateServiceProvider", item);
            await _serviceProviderInfoService.CreateAsync(item);
        }
    }
}
