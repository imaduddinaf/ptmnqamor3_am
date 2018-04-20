﻿using System.Collections.Generic;
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

            //if (_context.Locations.Count() == 0)
            //{
            //    _context.Locations.Add(Location.GetKP());
            //    _context.Locations.Add(Location.GetMORIII());
            //    _context.Locations.Add(Location.GetMORV());
            //    _context.SaveChanges();
            //}
        }

        [HttpGet]
        public BaseResponse<List<Location>> GetAll()
        {
            return Helper<List<Location>>.GetJSONResponse(true, null, _context.Locations.ToList());
        }

        [HttpGet("{id}", Name = "GetLocationByIdJSON")]
        public BaseResponse<Location> GetByIdJSON(long id)
        {
            return Helper<Location>.GetJSONResponse(true, null, GetLocation(id));
        }

        public Location GetLocation(long id)
        {
            Location item = _context.Locations.FirstOrDefault(t => t.id == id);

            return item;
        }
    }
}