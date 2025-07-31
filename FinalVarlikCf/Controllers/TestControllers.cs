using Microsoft.EntityFrameworkCore;
using FinalVarlikCf.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinalVarlikCf.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestControllers : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Swagger başarıyla çalışıyor!");
        }
    }
}



//using Microsoft.AspNetCore.Mvc;   bu paketle birlikte 
//ControllerBase

//IActionResult

//[HttpGet]

//[ApiController]
//UseSwagger(), UseRouting() gibi metodlar...

//Hepsi bu referans sayesinde otomatik yüklü geliyor.

