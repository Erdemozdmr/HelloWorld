using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIOrnek.Models.db;
using WebAPIOrnek.ViewModels;

namespace WebAPIOrnek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArabaController : ControllerBase
    {


        /// <summary>
        /// Araba Markalarını Getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            ArabaDBContext ctx = new ArabaDBContext();
            var markaListe = ctx.Tblmarkas.ToList();
            return Ok(markaListe);
        }

        // araba marka ve model bilgilerini getir
        [HttpGet("(id)")]

        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            ArabaDBContext ctx = new ArabaDBContext();
            var modelListesi = ctx.Tblmodels.Where(satir => satir.Markaid == id).ToList();

            if (modelListesi.Count == 0)
                return BadRequest("kayıt yok");

            return Ok(modelListesi);
        }

        //[HttpPost]

        //public async Task<ActionResult<List<Tblmarka>>> MarkaEkle(Tblmarka marka)
        //{
        //    ArabaDBContext ctx = new ArabaDBContext();
        //    ctx.Tblmarkas.Add(marka);
        //    ctx.SaveChanges();
        //    return Ok(ctx.Tblmarkas.ToList());
        //}

        [HttpPost]

        public async Task<ActionResult<List<Tblmodel>>> ModelEkle(Tblmodel model, int id)
        {
            ArabaDBContext ctx = new ArabaDBContext();
            model.Markaid = id;
            ctx.Tblmodels.Add(model);
            ctx.SaveChanges();
            return Ok(ctx.Tblmodels.ToList());
        }
    }
}
