﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria_API.Models;

namespace Pizzeria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly _2019SBDContext _context;
        public RestaurantsController(_2019SBDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Restaurants.Where(o => o.IsActive ?? false).ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Restaurants element = _context.Restaurants.FirstOrDefault(o => o.Id == id && (o.IsActive ?? false));

            if (element == null) return NotFound();

            return Ok(element);
        }
    }
}