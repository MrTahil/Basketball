using Basketteam_api.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Basketteam_api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class DataController : ControllerBase
        {
            [HttpPost]
            public ActionResult<Matchdatum> Post(Postmatchdata pdto)
            {
                var data = new Matchdatum
                {
                    Id=Convert.ToString(Guid.NewGuid()),
                    Try=pdto.Try,
                    Goal=pdto.Goal,
                    Fault=pdto.Fault,
                    PlayerId=pdto.PlayerId,
                    In=DateTime.Now,
                    Out=DateTime.Now,
                    CreatedTime=DateTime.Now,
                    UpdatedTime=DateTime.Now,
                };

                if (data != null)
                {
                    using (var context = new BasketteamContext())
                    {
                        context.Matchdata.Add(data);
                        context.SaveChanges();
                        return StatusCode(201, data);

                    }
                }
                return BadRequest();
            }

            [HttpGet]
            public ActionResult<Matchdatum> Get()
            {
                using (var context = new BasketteamContext())
                {
                    return Ok(context.Matchdata.ToList());
                }
            }

            [HttpGet("{id}")]
            public ActionResult<Matchdatum> GetById(Guid id)
            {
                using (var context = new BasketteamContext())
                {
                    var data = context.Matchdata.FirstOrDefault(x => x.Id == Convert.ToString(id));

                    if (data != null)
                    {
                        return Ok(data);
                    }

                    return NotFound();
                }
            }

            [HttpPut("{id}")]
            public ActionResult<Matchdatum> Put(Updatematchdata upddto, Guid id)
            {
                using (var context = new BasketteamContext())
                {
                    var livedata = context.Matchdata.FirstOrDefault(x => x.Id == Convert.ToString(id));

                    if (livedata != null)
                    {
                        livedata.Fault = upddto.Fault;
                        livedata.Try=upddto.Try;
                        livedata.Goal=upddto.Goal;
                    livedata.UpdatedTime=DateTime.Now;

                        context.Matchdata.Update(livedata);
                        context.SaveChanges();

                        return Ok(livedata);
                    }

                    return NotFound();
                }
            }

            [HttpDelete("{id}")]
            public ActionResult Delete(Guid id)
            {
                using (var context = new BasketteamContext())
                {
                    var data = context.Matchdata.FirstOrDefault(x => x.Id == Convert.ToString(id));

                    if (data != null)
                    {
                        context.Matchdata.Remove(data);
                        context.SaveChanges();
                        return Ok(new { messege = "Sikeres törlés." });
                    }

                    return NotFound();
                }
            }
        }
    }
