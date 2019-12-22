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
    public class OrderItemsController : ControllerBase
    {
        private readonly _2019SBDContext _context;
        public OrderItemsController(_2019SBDContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.OrderItems.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            OrderItems element = _context.OrderItems.FirstOrDefault(o => o.Id == id);

            if (element == null) return NotFound();

            return Ok(element);
        }

        [HttpPost]
        public IActionResult Create(OrderItems newElement)
        {
            _context.OrderItems.Add(newElement);
            _context.SaveChanges();

            return StatusCode(201, newElement);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, OrderItems element)
        {
            if (element.Id != id) return BadRequest();
            if (!_context.OrderItems.Any(o => o.Id == id)) return NotFound();

            _context.OrderItems.Attach(element);
            _context.Entry(element).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok(element);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id, OrderItems element)
        {
            if (element.Id != id) return BadRequest();
            if (!_context.OrderItems.Any(o => o.Id == id)) return NotFound();

            _context.Remove(element);
            _context.SaveChanges();

            return Ok(element);
        }
    }
}