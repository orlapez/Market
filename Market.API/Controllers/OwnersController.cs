

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Market.API.Data;
using Market.Shared.DTOs;
using Market.Shared.Entities;
using Market.API.Helpers;

namespace Market.API.Controllers
{

    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/owners")]
    public class OwnersController:ControllerBase
    {
        private readonly DataContext _context;
    
        public OwnersController(DataContext context)
        {


            _context = context; 
        }


        [HttpPost]
        public async Task<ActionResult>Post(Owner owner)
        {

            try
            {

                _context.Add(owner);
            await _context.SaveChangesAsync();


            return Ok();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un país con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }




        // Get Lista

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Owners
                .Include(x => x.Name)
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }



            return Ok(await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync());
        }


        


    }

}