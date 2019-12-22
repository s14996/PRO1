using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria_API.Models;
using Pizzeria_API.Utils;

namespace Pizzeria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCodesController : ControllerBase
    {
        private readonly _2019SBDContext _context;
        public DiscountCodesController(_2019SBDContext context)
        {
            _context = context;
        }

        [HttpGet("{code:string}")]
        public IActionResult GetByCode(string code)
        {
            DiscountCodes discountCode = _context.DiscountCodes.FirstOrDefault(o => o.Code.EqualsCaseInsensitive(code) && (o.IsActive ?? false));

            if (discountCode == null) return NotFound();

            return Ok(discountCode);
        }
    }
}