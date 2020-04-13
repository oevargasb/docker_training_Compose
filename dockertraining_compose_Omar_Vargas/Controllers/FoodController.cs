using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dockertraining_compose_Omar_Vargas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dockertraining_compose_Omar_Vargas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly FoodContext db;

        public FoodController(FoodContext context)
        {
            db = context;
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFood(int id)
        {
            var food = await db.Foods.FindAsync(id);
            if (food == default(Food))
            {
                return NotFound();
            }
            return Ok(food);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddFood([FromBody] Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.AddAsync(food);
            await db.SaveChangesAsync();
            return Ok(food.Id);
        }
    }
}