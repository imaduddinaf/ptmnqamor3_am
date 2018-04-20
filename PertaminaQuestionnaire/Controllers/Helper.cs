using System;
using PertaminaQuestionnaire.Models;

namespace PertaminaQuestionnaire.Controllers
{
    public static class Helper<T>
    {

        public static BaseResponse<T> GetJSONResponse(bool success, string message, T item)
        {
            var defaultMessage = item != null ? "Sukses menampilkan data" : "Gagal menampilkan data";

            return new BaseResponse<T>
            {
                status = success ? "SUCCESS" : "FAILED",
                message = message != null ? message : defaultMessage,
                data = item
            };
        }
    }
}
