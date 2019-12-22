using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria_API.Models;

namespace Pizzeria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly _2019SBDContext _context;
        public OrdersController(_2019SBDContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Orders element = _context.Orders.FirstOrDefault(o => o.Id == id && o.Status.Id != -1);

            if (element == null) return NotFound();

            return Ok(element);
        }

        [HttpPost]
        public IActionResult Create(Orders newElement)
        {
            _context.Orders.Add(newElement);
            _context.SaveChanges();

            return StatusCode(201, newElement);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Orders element)
        {
            if (element.Id != id) return BadRequest();
            if (!_context.Orders.Any(o => o.Id == id)) return NotFound();

            _context.Orders.Attach(element);
            _context.Entry(element).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok(element);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id, Orders element)
        {
            if (element.Id != id) return BadRequest();
            if (!_context.Orders.Any(o => o.Id == id)) return NotFound();

            _context.Remove(element);
            _context.SaveChanges();

            return Ok(element);
        }
    }
}