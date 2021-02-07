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


        public IActionResult Index()
        {
            buttons.Add(new ButtonModel { Id = 0, ButtonState = 0 });
            buttons.Add(new ButtonModel { Id = 1, ButtonState = 3 });
            buttons.Add(new ButtonModel { Id = 2, ButtonState = 0 });
            buttons.Add(new ButtonModel { Id = 3, ButtonState = 1 });
            buttons.Add(new ButtonModel { Id = 4, ButtonState = 2 });

            return View("Index", buttons);
        }
    }
}
