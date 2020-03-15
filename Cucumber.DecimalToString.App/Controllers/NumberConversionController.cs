using Cucumber.DecimalToString.App.Models;
using Cucumber.DecimalToString.App.RequestModels;
using Cucumber.DecimalToString.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Cucumber.DecimalToString.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberConversionController : ControllerBase
    {
        [HttpPost]
        public ActionResult<NumberToStringResponse> GetNumberAsString([FromBody] NumberToStringRequest request)
        {
            var number = decimal.Parse(request.Number);
            return new NumberToStringResponse { Number = number.ToStringRepresentation(), FirstName = request.FirstName, LastName = request.LastName };
        }
    }
}
