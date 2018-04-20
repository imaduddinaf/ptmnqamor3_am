using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PertaminaQuestionnaire.Models;

namespace PertaminaQuestionnaire.Controllers
{
    [Route("api/[controller]")]
    public class FeedbacksController
    {
        private readonly PertaminaQADBContext _context;

        public FeedbacksController(PertaminaQADBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public BaseResponse<List<Feedback>> GetAll([System.Web.Http.FromUri] long location_id)
        {
            if (location_id > 0)
            {
                return GetByLocationId(location_id);
            }
            else
            {
                return Helper<List<Feedback>>.GetJSONResponse(true, null, _context.Feedbacks.ToList());
            }
        }

        [HttpGet("{id}")]
        public BaseResponse<Feedback> GetById(int id)
        {
            Feedback feedback = _context.Feedbacks.FirstOrDefault(t => t.id == id);

            return Helper<Feedback>.GetJSONResponse(true, null, feedback);
        }

        public BaseResponse<List<Feedback>> GetByLocationId([System.Web.Http.FromUri] long location_id)
        {
            List<Feedback> feedbacks = _context.Feedbacks.Where<Feedback>(f => f.location_id == location_id).ToList();
           
            return Helper<List<Feedback>>.GetJSONResponse(true, null, feedbacks);
        }

        [HttpPost]
        public BaseResponse<Feedback> PostFeedback(bool is_like, long location_id)
        {
            LocationsController locationController = new LocationsController(_context);

            Feedback item = new Feedback
            {
                is_like = is_like,
                location_id = location_id
            };

            _context.Feedbacks.Add(item);
            _context.SaveChanges();

            return Helper<Feedback>.GetJSONResponse(true, null, item);
        }
    }
}
