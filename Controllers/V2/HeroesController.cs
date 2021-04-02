using System;
using System.Collections.Generic;
using Heroes.Api.Contracts.Models;
using Heroes.Api.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Heroes.Api.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HeroesController : ControllerBase
    {
        private readonly ILogger<HeroesController> _logger;
        private readonly IHeroesRepository _data;

        public HeroesController(ILogger<HeroesController> logger, IHeroesRepository data)
        {
            _logger = logger;
            _data = data;
        }

        
        [MapToApiVersion("2.0")]
        [HttpGet, Route("alive")]
        public string Alive()
        {
            return "Captain, 2.0 Here. I'm Alive and Kicking!";
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return _data.All();
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public Hero Post(HeroItem model)
        {
            var item = new Hero
            {
                Category = model.Category,
                HasCape = model.HasCape,
                IsAlive = model.IsAlive,
                Name = model.Name,
                Powers = model.Powers
            };
            return _data.Create(item);
        }

        [MapToApiVersion("2.0")]
        [HttpGet, Route("searchbyname")]
        public IEnumerable<Hero> SearchByName(string name = "")
        {
            return _data.Search(x => x.Name.Contains(name));
        }

        [MapToApiVersion("2.0")]
        [HttpGet, Route("categories")]
        public IEnumerable<string> Categories()
        {
            return (string[])Enum.GetNames(typeof(Category));
        }
    }
}
