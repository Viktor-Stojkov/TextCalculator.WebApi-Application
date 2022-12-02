using Microsoft.AspNetCore.Mvc;
using TextCalculator.BusinessLayer;

namespace TextCalculator.WebApi.Controllers
{

    /// <summary>
    /// Web Api Controller that handles incoming HTTP requests and send response back to the caller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]  //the route is https://localhost:7271/api/Calculator
    public class CalculatorController : ControllerBase
    {
        CalculatorService calculatorService;

        public CalculatorController()
        {
            calculatorService = new CalculatorService();
        }

        /// <summary>
        /// Handles Http requests for calculations. It calls the service to sum the numbers from the string.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Succesfull result with the sum in string or BadRequest if something failes</returns>
        [HttpPost]
        public async Task<ActionResult<string>> Calculate([FromBody]string number)
        {
            try
            {
                return calculatorService.Add(number);
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
