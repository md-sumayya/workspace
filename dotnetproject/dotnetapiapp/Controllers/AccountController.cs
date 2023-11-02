using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetapiapp.Models;
using dotnetapiapp.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace dotnetapiapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly OrderDeliveryDbContext _context;
        public AccountController(OrderDeliveryDbContext context){
            _context = context;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult> Login(Login model){
            try{
                var user = await _context.Users.FirstOrDefaultAsync(o=>o.Email == model.Email);
                if(user == null){
                    return NotFound();
                }
                var passwordHash = PasswordHelper.ComputeHash(model.Password,user.PasswordSalt);
                if(user.PasswordHash != passwordHash){
                    return BadRequest();
                }
                var token = TokenHelper.GenerateToken(user.UserName,user.UserRole.ToString());
                return Ok(token);
            }
            catch(Exception ex){
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(Register model){
            try{
                var user = new User(model);
                var salt = PasswordHelper.GenerateSalt();
                var passwordHash = PasswordHelper.ComputeHash(model.Password,salt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = salt;
                _context.Users.Add(user);
                _context.SaveChanges();
                var token = TokenHelper.GenerateToken(user.UserName,user.UserRole.ToString());
                return Ok(token);
            }
            catch(Exception ex){
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Get(){
            return Ok("success auth");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Admin")]
        public async Task<ActionResult> Admin(){
            return Ok("success auth");
        }

        [HttpGet]
        [Authorize(Roles = "DeliveryBoy")]
        [Route("DeliveryBoy")]
        public async Task<ActionResult> DevilveryBoy(){
            return Ok("success auth");
        }
    }
}