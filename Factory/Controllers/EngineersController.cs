using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

        public ActionResult Index(string searchString)
    {
      ViewBag.PageTitle = "View All Machines";
      if (!String.IsNullOrEmpty(searchString))
      {
        List<Engineer> model = _db.Engineers
          .Where(engineer => engineer.EngineerName.Contains(searchString))
          .OrderBy(engineer => engineer.EngineerName)
          .ToList();
        return View(model);
      }
      else
      {
        List<Engineer> model = _db.Engineers
          .OrderBy(engineer => engineer.EngineerName)
          .ToList();
        return View(model);
      }
    }

  }
}
