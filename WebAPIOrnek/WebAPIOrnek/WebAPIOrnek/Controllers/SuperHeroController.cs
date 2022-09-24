using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIOrnek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        //static bir liste tanımlayalım super kahramanlari iiçinde tutan.
        private static List<SuperHero> heroes = new List<SuperHero>()
        {
            new SuperHero
            {
                Id=1,
                FirstName="Spider",
                LastName="Man",
                Place="NYC"
            },
            new SuperHero
            {
                Id=2,
                FirstName="Yaman",
                LastName="Yıldırım",
                Place="AUS"
            }
        };

        //SUPER KAHRAMANLARIN LİSTELEMEYE YARAYAN METOT.
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            //ok
            return Ok(heroes);        
        }

        //parametre olarak id alan heroes listesinde o idli super kahramanı bulup getiren metot.
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            var hero= heroes.Find(satir => satir.Id == id);
            if (hero == null)
                return BadRequest("kayıt yok");
            return Ok(hero);
        }

        //kayıt ekleyen metot.
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        //delete 
        //httpdelete
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heroes.Find(satir => satir.Id == id);
            if (hero == null)
                return BadRequest("kayıt yok");

            heroes.Remove(hero);
            return Ok(heroes);
        }

        //guncelleme        
        //httpPut
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(satir => satir.Id == request.Id);
            if (hero == null)
                return BadRequest("kayıt yok");

            hero.FirstName= request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(heroes);
        }



    }
}
