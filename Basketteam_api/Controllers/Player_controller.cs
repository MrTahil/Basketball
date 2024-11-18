using Basketteam_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Basketteam_api.Controllers
{
    [Route("player")]
    [ApiController]
    public class Player_controller : Controller
    {
        [HttpPost]
        public ActionResult<Player> Post(CreatePlayer player1) {
            var player = new Player()
            {
                Id = Convert.ToString(Guid.NewGuid()),
                Name = player1.Name,
                Height = player1.Height,
                Weight  = player1.Weight,
                CreatedTime= DateTime.Now
            };
            if (player != null)
            {
                using (var context = new BasketteamContext())
                {
                    context.Players.Add(player);
                    context.SaveChanges();
                    return StatusCode(201, player);

                }
            }

            return BadRequest();
            
        }

        [HttpGet]
        public ActionResult<Player> Get()
        {
            using (var context = new BasketteamContext())
            {
                return Ok(context.Players.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Player> GetById(Guid id)
        {
            using (var context = new BasketteamContext())
            {
                var player = context.Players.FirstOrDefault(x => x.Id == Convert.ToString(id));

                if (player != null)
                {
                    return Ok(player);
                }

                return NotFound();
            }

        }


        [HttpPut("{id}")]
        public ActionResult<Player> Put(UpdatePlayer uplayer, Guid id)
        {
            using (var context = new BasketteamContext())
            {
                var existingPlayer = context.Players.FirstOrDefault(x => x.Id == Convert.ToString(id));

                if (existingPlayer != null)
                {
                    existingPlayer.Name = uplayer.Name;
                    existingPlayer.Height = uplayer.Height;
                    existingPlayer.Weight = uplayer.Weight;

                    context.Players.Update(existingPlayer);
                    context.SaveChanges();
                    return Ok(existingPlayer);
                }

                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            using (var context = new BasketteamContext())
            {
                var player = context.Players.FirstOrDefault(x => x.Id == Convert.ToString(id));

                if (player != null)
                {
                    context.Players.Remove(player);
                    context.SaveChanges();
                    return Ok(new { messege = "Sikeres törlés." });
                }

                return NotFound();
            }
        }






        [HttpGet("playerData/{id}")]
        public ActionResult<Player> GetPlayerData(Guid id)
        {
            using (var contex = new BasketteamContext())
            {
                var player = contex.Players.Include(x => x.Matchdata).FirstOrDefault(player => player.Id == Convert.ToString(id));

                if (player != null)
                {
                    return Ok(player);
                }

                return NotFound();
            }
        }

        [HttpGet("Matchdata/{id}")]
        public ActionResult<Matchdatum> GetMatchData(Guid id)
        {
            using (var contex = new BasketteamContext())
            {

                var player = contex.Players.FirstOrDefault(x => x.Id == Convert.ToString(id));

                var data = contex.Matchdata.Select(x => new { player.Name, x.Goal,x.Fault,x.Try, x.PlayerId }).Where(x => x.PlayerId == Convert.ToString(id)).ToList(); ;



                if (data != null)
                {
                    return Ok(data);
                }

                return NotFound();
            }
        }
    }
}
