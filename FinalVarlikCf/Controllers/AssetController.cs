using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalVarlikCf.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AssetController>/5
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST api/<AssetController>
        [HttpPost]
        public void Create([FromBody] string value)
        {
        }
        //en son bu satırı yorum satırına aldım  ama kullanılıyor bu

        // PUT api/<AssetController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        //[HttpPost("getbyId/{id}")]
        //public Post? GetById(int Id)
        //{


        //    PostService postService = new PostService();
        //    var data = postService.GetAll(Id);
        //    postService? post = data.FirstOrDefaultx=>x.id==Id);
        //    return post;


        //}

        //[HttpGet]
        //public int SayiGetir()
        //{
        //    return 200;
        //}

    }
}
