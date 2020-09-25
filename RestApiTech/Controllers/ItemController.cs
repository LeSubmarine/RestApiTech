using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;

namespace RestApiTech.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private static List<Item> ItemListTemp = new List<Item>(){new Item(0,"Pants","Decent",4),new Item(1,"Shoes","Good",2),new Item(2,"Jacket","Great",5),new Item(3,"Shirt","Poor",512),new Item(4,"Hat","Mediocre",10)};

        // GET: Item
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return ItemListTemp;
        }
        [HttpGet]
        [Route("Name/{substring}")]
        public IEnumerable<Item> GetFromSubstring(String substring)
        { 
            return ItemListTemp.FindAll(i => i.Name.ToLower().Contains(substring.ToLower()));
        }
        [HttpGet]
        [Route("Quality/{substring}")]
        public IEnumerable<Item> GetFromQuality(String substring)
        {
            return ItemListTemp.FindAll(i => i.Quality.ToLower().Contains(substring.ToLower()));
        }
        [HttpGet]
        [Route("Search")]
        public IEnumerable<Item> GetFromQuality([FromQuery] FilterItem filter)
        {
            if (filter.HighQuantity != 0)
            {
                return ItemListTemp.FindAll(i => i.Quantity >= filter.LowQuantity && i.Quantity <= filter.HighQuantity);

            }
            else
            {
                return ItemListTemp.FindAll(i => i.Quantity > filter.LowQuantity);
            }
        }

        // GET: Item/5
        [HttpGet]
        [Route("{id}")]
        public Item Get(int id)
        {
            foreach (var item in ItemListTemp)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return new Item();
        }

        // POST: Item
        [HttpPost]
        public void Post([FromBody] Item value)
        {
            for (int i = 0; i < ItemListTemp.Count; i++)
            {
                if (ItemListTemp[i].Id == value.Id)
                {
                    return;
                }
            }
            ItemListTemp.Add(value);
        }

        // PUT: Item/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] Item value)
        {
            for (int i = 0; i < ItemListTemp.Count; i++)
            {
                if (ItemListTemp[i].Id == id)
                {
                    ItemListTemp[i] = value;
                    break;
                }
            }
        }

        // DELETE: Item/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            for (int i = 0; i < ItemListTemp.Count; i++)
            {
                if (ItemListTemp[i].Id == id)
                {
                    ItemListTemp.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
