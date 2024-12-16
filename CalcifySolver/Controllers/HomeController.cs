using CalcifySolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalcifySolver.Controllers
{
    public class HomeController : Controller
    {
        // Display the initial form
        public ActionResult Index()
        {
            return View(new CalculatorModel()); // Pass an empty model
        }

        // Handle the form submission
        [HttpPost]
        public ActionResult Index(CalculatorModel model)
        {
            if (model != null)
            {
                // Perform the calculation based on the selected operation
                switch (model.Operation)
                {
                    case "Add":
                        model.Result = model.Number1 + model.Number2;
                        break;
                    case "Subtract":
                        model.Result = model.Number1 - model.Number2;
                        break;
                    case "Multiply":
                        model.Result = model.Number1 * model.Number2;
                        break;
                    case "Divide":
                        if (model.Number2 != 0)
                            model.Result = model.Number1 / model.Number2;
                        else
                            model.ErrorMessage = "Cannot divide by zero.";
                        break;
                    default:
                        model.ErrorMessage = "Invalid operation.";
                        break;
                }
            }

            // Pass the updated model back to the view
            return View(model);
        }
    }
}