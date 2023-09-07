﻿using Market.API.Data;
using Market.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.API.Controllers
{

    [ApiController]
    [Route("api/countries")]
    public class CountriesController:ControllerBase
    {

        private readonly DataContext _context;

         public CountriesController(DataContext context)
        {



            _context = context; 
        }


        //get por lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Countries.ToListAsync());
        }


        //Get por parámetro
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            
            var country= await _context.Countries.FirstOrDefaultAsync(x => x.Id == id); 
            if(country == null) { 
            
            return NotFound();  
            }

            return Ok(country);

        }

        // Post- Create
        [HttpPost]
        public async Task<ActionResult> Post(Country country)
        {

            _context.Add(country);
                await _context.SaveChangesAsync();  
            return Ok(country);
        }

    }
}