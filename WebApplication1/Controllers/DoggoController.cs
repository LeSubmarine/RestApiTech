using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class DoggoController : ApiController
    {
        // GET: api/Doggo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Doggo/5
        public Image Get(int id)
        {
            
                return Image.FromFile($"C:\\Users\\henri\\source\\repos\\RestApiTech\\WebApplication1\\Controllers\\Doggos\\{Convert.ToString(id)}.jpg");
            }

        // POST: api/Doggo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Doggo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Doggo/5
        public void Delete(int id)
        {
        }
    }
}
