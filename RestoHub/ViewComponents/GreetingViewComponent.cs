using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoHub.ViewComponents
{
    public class GreetingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default", "Hello");
        }
    }
}
