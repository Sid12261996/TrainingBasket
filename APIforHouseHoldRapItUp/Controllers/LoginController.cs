using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using APIforHouseHoldRapItUP.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Net;
using System.Web.Http;
using System.Net.Http;

namespace APIforHouseHoldRapItUP.Controllers
{
    public class LoginController : ApiController
    {
        private ApplicationSignInManager _signInManager;

       
        // GET: Login
        
        public async Task< HttpResponseMessage> LoginUser(LoginViewModel user)
        {

            
            var name = user.Email;
            var pass = user.Password;




            

            if (true)
            {
                var claimsdata = new[] { new Claim(ClaimTypes.Name, name) };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ahbasshfbsahjfbshajbfhjasbfashjbfsajhfvashjfashfbsahfbsahfksdjf"));
                var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                var token = new JwtSecurityToken(
                     issuer: "mysite.com",
                     audience: "mysite.com",
                     expires: DateTime.Now.AddMinutes(100),
                     claims: claimsdata,
                     signingCredentials: signInCred
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                //return Ok(tokenString);




                jsonres jsres = new jsonres();
                jsres.description = "Token is Succesfully Generated";
                jsres.status = "Success";
                jsres.token = tokenString + "";

                return Request.CreateResponse(HttpStatusCode.OK, jsres);


                //  return new Microsoft.AspNetCore.Mvc.JsonResult(jsres);
            }
            else
            {
                jsonres jsres = new jsonres();
                jsres.description = "Username or password is incorrect";
                jsres.status = "Failed";

                //return new Microsoft.AspNetCore.Mvc.JsonResult(jsres);
                return Request.CreateResponse(HttpStatusCode.OK, jsres);
            }
           
        }
    }

    class jsonres
    {
        public string description;
        public string status;
        public string token;
    }
}