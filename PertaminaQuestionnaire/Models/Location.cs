﻿using System;
using Newtonsoft.Json;

namespace PertaminaQuestionnaire.Models
{
    public class Location : BaseModel
    {
        public string name { get; set; }
        public Nullable<long> parent_id { get; set; }
    }
}
