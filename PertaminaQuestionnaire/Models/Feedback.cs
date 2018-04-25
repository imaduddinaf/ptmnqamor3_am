using System;
using Newtonsoft.Json;

namespace PertaminaQuestionnaire.Models
{
    public class Feedback : BaseModel
    {
        public bool is_like { get; set; }
        public long location_id { get; set; }
        public Nullable<DateTime> date { get; set; }
    }
}
