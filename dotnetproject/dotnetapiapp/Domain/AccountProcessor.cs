using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapiapp.Models;
using dotnetapiapp.Common;
using Microsoft.EntityFrameworkCore;
using dotnetapiapp.Repository;
using dotnetCommonUtils.Helpers;

namespace dotnetapiapp.Domain
{
    public interface IAccountProcessor{
        public Task<AuthResponse> Login(Login model);
        public Task<AuthResponse> Register(Register model);
        public Task<UserDetails> GetUserByEmail(string email);
    }
    public class AccountProcessor : IAccountProcessor
    {
        private readonly IAccountRepository _repo;
        public AccountProcessor(IAccountRepository repo){
            _repo = repo;
        }
        public async Task<AuthResponse> Login(Login model){
            var user = await _repo.GetUserByEmail(model.Email);
            if(user == null){
                throw new CustomException("User Not Found");
            }
            var passwordHash = PasswordHelper.ComputeHash(model.Password,user.PasswordSalt);
            if(user.PasswordHash != passwordHash){
                throw new CustomException("Passwords doesnot match");
            }
            var token = TokenHelper.GenerateToken(user.UserName,user.Email,user.UserRole.ToString());
            return new AuthResponse{Token=token,UserName=user.UserName,Email=user.Email};
        }

        public async Task<AuthResponse> Register(Register model){        
            var user = await _repo.GetUserByEmail(model.Email);
            if(user != null){
                throw new CustomException("User already exists");
            }    
            user = new User(model);
            var salt = PasswordHelper.GenerateSalt();
            var passwordHash = PasswordHelper.ComputeHash(model.Password,salt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = salt;
            user =  await _repo.CreateUser(user);
            var token = TokenHelper.GenerateToken(user.UserName,user.Email,user.UserRole.ToString());
            return new AuthResponse{Token=token,UserName=user.UserName,Email=user.Email};
        }

        public async Task<UserDetails> GetUserByEmail(string email){    
            var user = await _repo.GetUserByEmail(email);
            if(user == null){
                throw new CustomException("User not Found");
            }
            return new UserDetails(user);
        }
    }
}