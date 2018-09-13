using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NumberGame.Models;

namespace NumberGame.Controllers {
    public class HomeController : Controller {


        public ActionResult Index() {
            // got a random number?
            Random rnd = new Random();
            var MyNumber = rnd.Next(1, 100);
            Session["rndNumber"] = MyNumber;


            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public ActionResult GuessNumber(string guess) {
            decimal number;
            // Convert session to decimal
            decimal rndNumber = decimal.Parse(Session["rndNumber"].ToString());

            var success = decimal.TryParse(guess, out number);

            // Make sure user passed a number
            if (success == true) {
                string result = "You guessed correct!";
                while (number != rndNumber) {
                    if (number > rndNumber)
                        return Content("Your guess was too high.");
                    if (number < rndNumber) {
                        return Content("Your guess was too low.");
                    }
                }
                return Content(result);
            }
            else return Content("Please enter a valid number");
        }

        [HttpPost]
        public ActionResult InitiateNewGame() {
            Random rnd = new Random();
            var MyNumber = rnd.Next(1, 100);
            Session["rndNumber"] = MyNumber;
            return null;
        }
    }
}