using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text;
using TextCalculator.BusinessLayer;
using TextCalculator.Models;

namespace TextCalculator.Controllers
{

    /// <summary>
    /// MVC controller with methods that handles incoming browser requests, retrieves necessary model data and returns appropriate responses.
    /// </summary>
    public class CalculatorController : Controller
    { 

      
        /// <summary>
        /// Get method to return the view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            CalculatorViewModel model = new CalculatorViewModel();
            return View(model);
        }

        /// <summary>
        /// Post method the calculates the sum of the provided string.
        /// </summary>
        /// <param name="model">Calculator view model with value only for the number</param>
        /// <returns>View</returns>
        [HttpPost]
        public async Task<IActionResult> Index(CalculatorViewModel model)
        {
            try
            {
                //api url on whish the api listens
                string apiUrl = "https://localhost:7271/api/Calculator";

                //HTTPClient class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
                //This configuration was the most chalinging part for me
                using (HttpClient client = new HttpClient())
                {

                    //setting client uri from api url
                    client.BaseAddress = new Uri(apiUrl);

                    //serializing the model.Number string in jsonString
                    var jsonString = JsonConvert.SerializeObject(model.Number);

                    //setting content to be string content of type application/json
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    //sending a request to the api endpoint with the content
                    var postTask = await client.PostAsync(client.BaseAddress, content);

                    //result
                    var result = postTask.Content;

                    //if succesfull result code returened, set the model.Result to the returned result from the Api
                    if (postTask.IsSuccessStatusCode)
                    {
                        model.Result = await result.ReadAsStringAsync();
                    }
                    else
                    { 
                        //if the response is unsuccessful, it sets the model.ErrorMessage to the ex.ErrorMessage returned
                        model.ErrorMessage = await result.ReadAsStringAsync();
                    }


                }
            }
            catch(Exception ex)
            {
                //if exception thrown, it sets the model.ErrorMessage to the ex.ErrorMessage returned
                model.ErrorMessage = ex.Message;
            }
            return View(model);
        }
    }
}
