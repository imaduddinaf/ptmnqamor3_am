using System;

namespace PertaminaQuestionnaire.Models
{
    public class BaseResponse<T>
    {
        public string status { get; set; }
        public string message { get; set; }
        public T data { get; set; }

        public BaseResponse()
        {
        }
    }

    public class BaseModel {
        public long id { get; set; }
    }
}
