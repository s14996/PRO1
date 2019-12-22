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
    public class OrderItemIngridientsController : ControllerBase
    {
        private readonly _2019SBDContext _context;
        public OrderItemIngridientsController(_2019SBDContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.OrderItemsIngridients.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            OrderItemsIngridients element = _context.OrderItemsIngridients.FirstOrDefault(o => o.Id == id);

            if (element == null) return NotFound();

            return Ok(element);
        }

        [HttpPost]
        public IActionResult Create(OrderItemsIngridients newElement)
        {
            _context.OrderItemsIngridients.Add(newElement);
            _context.SaveChanges();

            return StatusCode(201, newElement);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, OrderItemsIngridients element)
        {
            if (element.Id != id) return BadRequest();
            if (!_context.OrderItemsIngridients.Any(o => o.Id == id)) return NotFound();

            _context.OrderItemsIngridients.Attach(element);
            _context.Entry(element).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok(element);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id, OrderItemsIngridients element)
        {
            if (element.Id != id) return BadRequest();
            if (!_context.OrderItemsIngridients.Any(o => o.Id == id)) return NotFound();

            _context.Remove(element);
            _context.SaveChanges();

            return Ok(element);
        }
    }
}