using System.Web.Http;
using Tickets.API.Utils;

namespace Tickets.API.Controllers
{
    public class ValidationController : ApiController
    {
        [Route("Validation")]
        [HttpGet]
        public IHttpActionResult Get(string dtoObjectName, string jsonObjectName)
        {
            var valHelper = new ValidationHelper();
            object jsonObject = valHelper.GetValidations(dtoObjectName, jsonObjectName, "Tickets.Model", false, "Tickets.Model");

            return Json(jsonObject);
        }
    }

    

}
