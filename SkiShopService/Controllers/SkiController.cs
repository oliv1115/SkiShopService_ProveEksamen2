﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiShopService.Model;

namespace SkiShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkiController : ControllerBase
    {
        private static readonly List<Ski> Skis = new List<Ski>()
        {
            new Ski(1,200,"Slalom",5000),
            new Ski(2,190,"Slalom",4500),
            new Ski(3,180,"CrossCountry",3500),
            new Ski(4,170,"FreeStyle",4000),
            new Ski(5,190,"Downhill",5000),
        };

        // GET: api/Ski
        [HttpGet]
        public IEnumerable<Ski> GetAllSkis()
        {
            return Skis;
        }

        //GET: api/Ski/5
        [HttpGet("{id}", Name = "Get")]
        public Ski GetId(int id)
        {
            return Skis.Find(i => i.Id.Equals(id));      
        }

        [HttpGet]
        [Route("/{substring}")]
        public IEnumerable<Ski> GetId(string substring)
        {
            return Skis.FindAll(i => i.SkiType.Contains(substring));
        }

        // POST: api/Ski
        [HttpPost]
        public void InsertSki([FromBody] Ski value)
        {
            Skis.Add(value);
        }

        //PUT: api/Ski/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Ski value)
        {
            Ski ski = GetId(id);
            if (ski != null)
            {
                ski.Id = value.Id;
                ski.SkiLength = value.SkiLength;
                ski.SkiType = value.SkiType;
                ski.Price = value.Price;
            }
        }


        // PUT: api/Skis/5
        [HttpGet]
        [Route("Price/{LowerPrice}-{UpperPrice}")]
        public IEnumerable<Ski> GetByPrice(int LowerPrice, int UpperPrice)
        {
            List<Ski> result = new List<Ski>();
            foreach (var v in Skis)
            {
                if (v.Price >= LowerPrice && v.Price <= UpperPrice)
                {
                    result.Add(v);
                }
            }
            return result;
        }

        // DELETE: api/Skis/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Ski ski = GetId(id);
            Skis.Remove(ski);
        }

    }
}
