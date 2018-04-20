using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PertaminaQuestionnaire.Models;
using System.Linq;

namespace PertaminaQuestionnaire.Controllers
{
    [Route("api/[controller]")]
    public class LocationsController : Controller
    {
        private readonly PertaminaQADBContext _context;

        public LocationsController(PertaminaQADBContext context)
        {
            _context = context;
        }

        //locations?parent_id={parent_id}
        [HttpGet] 
        public BaseResponse<List<Location>> GetAll([System.Web.Http.FromUri] long parent_id)
        {
            if (parent_id > 0) 
            {
                return GetByParentId(parent_id);
            }
            else
            {
                return Helper<List<Location>>.GetJSONResponse(true, null, _context.Locations.ToList());
            }
        }

        //locations/{id}
        [HttpGet("{id}")]
        public BaseResponse<Location> GetByIdJSON(long id)
        {
            return Helper<Location>.GetJSONResponse(true, null, GetLocation(id));
        }

        public BaseResponse<List<Location>> GetByParentId([System.Web.Http.FromUri] long parent_id)
        {
            List<Location> locations = _context.Locations.Where<Location>(l => l.parent_id == parent_id).ToList();

            return Helper<List<Location>>.GetJSONResponse(true, parent_id.ToString(), locations);
        }

        public Location GetLocation(long id)
        {
            Location item = _context.Locations.FirstOrDefault(t => t.id == id);

            return item;
        }
    }
}
