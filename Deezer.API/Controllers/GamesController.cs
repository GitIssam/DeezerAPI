using Microsoft.AspNetCore.Mvc;
using Deezer.BlindTest.Tools;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deezer.API.Controllers
{
    
    //[HttpGet]
    //public ViewModels.Joke GetGames();

    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // variable global 
        Db _db;
        public GamesController()
        {
            
            var connectionString = "Initial Catalog = FileRougeCorrection;Data Source=DESKTOP-6EPS2V4;User ID=DbFileRougeCorrection;Password=DbFileRougeCorrection;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //l'objet db pour utiliser des méthodes dans celle ci
            _db = new Db(connectionString);
        }
        // GET: api/<GamesController>
        [EnableCors("MyPolicy")]
        [HttpGet]

        public List<Game> GetGames()

        {

            return _db.GetGames();
        }

        [HttpGet("{id}")]
        //public Game GetGame(int id)
        //{
        //    return _db.GetGames().FirstOrDefault(x => x.id == id);
        //}
        public Game GetGame(int id)

        {
            return _db.GetGames().First(g => g.Id == id);
        }


        // GET api/<GamesController>/5/Tracks
        [EnableCors("MyPolicy")]
        [HttpGet("{id}/Tracks")]
 
        public List<Track> GetTracks(int id)

        {
            return _db.GetTrackFromGames(id);
        }




        // POST api/<GamesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
