using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : Controller
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper mapper;

        public RestaurantController(RestaurantDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
        }
        
        
        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurants=_dbContext
                .Restaurants
                .Include(r=>r.Address)
                .Include(r=>r.Dishes)
                .ToList();

            var restaurantsDtos=mapper.Map<List<RestaurantDto>>(restaurants);

            return Ok(restaurantsDtos);
        }
       
        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant= _dbContext 
                .Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .FirstOrDefault(x => x.Id == id);

            if (restaurant is null)
            {
                return NotFound();
            }

            var restaurantDto= mapper.Map<RestaurantDto>(restaurant);
            return Ok(restaurantDto);
        }
        


      
    }
}
