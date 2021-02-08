using ButtonGrid.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButtonGrid.Controllers
{
    public class ButtonController : Controller
    {
        static List<ButtonModel> buttons = new List<ButtonModel>();

        Random random = new Random();
        const int GRID_SIZE = 25;


        public IActionResult Index()
        {
            if (buttons.Count < GRID_SIZE)
            {
                for (int i = 0; i < GRID_SIZE; i++)
                {
                    buttons.Add(new ButtonModel { Id = i, ButtonState = random.Next(4) });
                }
            }

            ViewBag.Message = "Make all the buttons to be same color!";

            return View("Index", buttons);
        }

        public IActionResult HandleButtonClick(string buttonNumber)
        {
            int bn = int.Parse(buttonNumber);

            buttons.ElementAt(bn).ButtonState = (buttons.ElementAt(bn).ButtonState + 1) % 4;

            bool state = false;
            for (int i = 0; i < GRID_SIZE - 1; i++)
            {                
                if (buttons.ElementAt(0).ButtonState != buttons.ElementAt(i + 1).ButtonState)
                {
                    state = true;
                    break;
                }
            }

            if (!state)
            {
                ViewBag.Message = "You won!";
            }
            else
            {
                ViewBag.Message = "Keep pressing!";
            }

            return View("Index", buttons);
        }
    }
}
