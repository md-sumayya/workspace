using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetmvcapp.RouteConstants;
using dotnetmvcapp.Models;
using dotnetCommonUtils.CommonModels;

namespace dotnetmvcapp.Services
{
    public interface IAccountService {
        public Task<ResponseObject<AuthResponse>> Login(Login model);
        public Task<ResponseObject<AuthResponse>> Register(Register model);
    }
    public class AccountService : IAccountService
    {
        private readonly IHttpClientService _httpClientService;
        public AccountService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ResponseObject<AuthResponse>> Login(Login model){
            var resp = await _httpClientService.Post<AuthResponse>(RouteConstants.AccountServiceRoutes.Login,model);
            return resp;
        }
        public async Task<ResponseObject<AuthResponse>> Register(Register model){
            var resp = await _httpClientService.Post<AuthResponse>(RouteConstants.AccountServiceRoutes.Register,model);
            return resp;
        }
    }
}