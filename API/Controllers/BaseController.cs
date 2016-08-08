using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Tickets.API.Controllers
{
    public class BaseController : ApiController
    {
        protected int GetLoggedUserId() {
            return 0;
        }

        protected object GetPagedResult(object res,int total)
        {
            dynamic myobject = new ExpandoObject();
            IDictionary<string, object> result = myobject;
            result.Add("result", res);
            result.Add("totalRecords", total);
            return result;
        }

        protected object GetResult(object res)
        {
            dynamic myobject = new ExpandoObject();
            IDictionary<string, object> result = myobject;
            result.Add("result", res);
            return result;
        }

    }
}
