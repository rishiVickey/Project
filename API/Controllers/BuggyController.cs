using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly storeContext _context;
        public BuggyController(storeContext context)
        {
            _context = context;
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "Secret stuff";
        }

        [HttpGet("notfound")]
        public ActionResult GetNotNotFoundRequest()
        {
            var things = _context.products.Find(42);
            if(things == null){
                return NotFound( new ApiResponse(404));
            }
            return Ok();
        }

        
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var things = _context.products.Find(42);
            var thingToReturn = things.ToString();
            return Ok();
        }

        
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {

            return BadRequest(new ApiResponse(400));
        }

           
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {

            return Ok();
        }
    }
}