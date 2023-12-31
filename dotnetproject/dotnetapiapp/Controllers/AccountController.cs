using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetapiapp.Models;
using Microsoft.AspNetCore.Authorization;
using dotnetapiapp.Common;
using dotnetapiapp.Domain;
using dotnetCommonUtils.CommonModels;

namespace dotnetapiapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountProcessor _processor; 
        public AccountController(IAccountProcessor processor){
            _processor = processor;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult> Login(Login model){
            try{
                var result = await _processor.Login(model);
                var response = new ResponseObject<AuthResponse>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch(CustomException ex){
                var response = new ResponseObject<AuthResponse>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch(Exception ex){           
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(Register model){
            try{
                var result = await _processor.Register(model);
                var response = new ResponseObject<AuthResponse>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch(CustomException ex){
                var response = new ResponseObject<AuthResponse>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch(Exception ex){
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserDetailsByEmail/{email}")]
        public async Task<ActionResult> GetUserDetailsByEmail(string email){
            try{
                var result = await _processor.GetUserByEmail(email);
                var response = new ResponseObject<UserDetails>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch(CustomException ex){
                var response = new ResponseObject<UserDetails>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch(Exception ex){
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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

        [HttpGet]
        [Route("Test")]
        public async Task<ActionResult> Test(){
            return Ok("success auth");
        }
    }
}