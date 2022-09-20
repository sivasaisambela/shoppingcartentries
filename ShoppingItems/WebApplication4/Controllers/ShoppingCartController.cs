using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Models;
using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    [ApiController]
    public class ShoppingCartController : Controller
    {
       
        private readonly IItemRepository _context;

        public ShoppingCartController(IItemRepository context)
        {
            _context = context;
        }

      
     
       
        [HttpGet]
        [Route("")]
        [Route("[controller]")]
        public IActionResult GetItems()
        {
            
           
            var items = _context.GetItems();
            if(items!=null)
            {
                return Ok(items);

            }
            else
            {
                return Unauthorized();
            }
        }


        [HttpGet]
        [Route("[controller]/{itemId:int}")]
        public IActionResult GetEmpployeeByIdAsync([FromRoute] int itemId)
        {
            string xyzHeader = Request.Headers["BarCode"];
            var items = _context.GetItems(x => x.BarCode == xyzHeader, false);
            if (items != null&& items.Count>0)
            {


                var item = _context.GetItems(x => x.Itemld == itemId, false).ToList();

                if (item == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(item);
                }
            }
            else
            {
                return Unauthorized();
            }

            
        }

        [HttpGet]
        [Route("[controller]/AddUser")]
        public IActionResult CreateUser(User user)
        {
            if (user != null)
            {
                if(user.ItemId>0&&user.Email!=null)
                {
                     var usrresult = _context.AddUser(user);
                    if (usrresult != null)
                    {
                        return Ok(usrresult);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return Unauthorized();
                }

                           
               
            }
            else
            {
                return BadRequest();
            }
           
        }


    }
}
