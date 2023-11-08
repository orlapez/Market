using Market.API.Data;
using Market.Shared.DTOs;
using Market.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.API.Controllers
{

    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/pets")]
    public class PetsController : ControllerBase
    {
        private readonly DataContext _context;

        public PetsController(DataContext context)
        {


            _context = context;
        }


       
        // Get Lista

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Pets
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }



            return Ok(await queryable
                .OrderBy(x => x.Name)
                .ToListAsync());
        }

    }

}