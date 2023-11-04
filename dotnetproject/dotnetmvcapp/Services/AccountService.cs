using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetmvcapp.RouteConstants;
using dotnetmvcapp.Models;

namespace dotnetmvcapp.Services
{
    public interface IAccountService {
        public Task<AuthResponse> Login(Login model);
        public Task<AuthResponse> Register(Register model);
    }
    public class AccountService : IAccountService
    {
        private readonly IHttpClientService _httpClientService;
        public AccountService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<AuthResponse> Login(Login model){
            try{
            var resp = await _httpClientService.Post<AuthResponse>(RouteConstants.AccountServiceRoutes.Login,model);
            return resp;
            }
            catch(Exception ex){
                return new AuthResponse();
            }
        }
        public async Task<AuthResponse> Register(Register model){
            var resp = await _httpClientService.Post<AuthResponse>(RouteConstants.AccountServiceRoutes.Register,model);
            return resp;
        }
    }
}