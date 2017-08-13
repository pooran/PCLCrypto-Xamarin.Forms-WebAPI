
using CryptoSampleAPI.Models;
using Newtonsoft.Json;
using System.Web.Http;

namespace CryptoSampleAPI.Controllers
{
    public class CryptoController : ApiController
    {
      
        [HttpPost]
        [Route("api/Login")]
        public IHttpActionResult Login(string loginInfo)
        {
            var decryptedLoginInfo = CryptoSample.Crypto.Decrypt(loginInfo);
            var loginModel =JsonConvert.DeserializeObject<LoginModel>(decryptedLoginInfo);
           
            return Ok(loginModel.UserName + " " + loginModel.Password  );
        }
        
    }
}
