using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index(string searchString)
    {
      ViewBag.PageTitle = "View All Engineers";
      if (!String.IsNullOrEmpty(searchString))
      {
        List<Machine> model = _db.Machines
          .Where(machine => machine.MachineName.Contains(searchString))
          .OrderBy(machine => machine.MachineName)
          .ToList();
        return View(model);
      }
      else
      {
        List<Machine> model = _db.Machines
          .OrderBy(machine => machine.MachineName)
          .ToList();
        return View(model);
      }
    }

    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine, int EngineerId)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      if (EngineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = EngineerId, MachineId = machine.MachineId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

  //   public ActionResult Details(int id)
  //   {
  //     var thisProduct = _db.Products
  //       .Include(product => product.JoinEntities)
  //       .ThenInclude(join => join.Supplier)
  //       .FirstOrDefault(product => product.ProductId == id);
  //     return View(thisProduct);
  //   }

  //   public ActionResult Delete (int id)
  //   {
  //     var thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
  //     return View(thisProduct);
  //   }

  //   [HttpPost, ActionName("Delete")]
  //   public ActionResult DeleteConfirmed(int id)
  //   {
  //     var thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
  //     _db.Products.Remove(thisProduct);
  //     _db.SaveChanges();
  //     return RedirectToAction("Index");
  //   }

  //   public ActionResult Edit(int id)
  //   {
  //     var thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
  //     ViewBag.ProductId = new SelectList(_db.Suppliers, "SupplierId", "SupplierName");
  //     return View(thisProduct);
  //   }

  //   [HttpPost] 
  //   public ActionResult Edit (Product product, int SupplierId)
  //   {
  //     if (SupplierId != 0)
  //     {
  //       _db.ProductSupplier.Add(new ProductSupplier() { SupplierId = SupplierId, ProductId = product.ProductId });
  //     }
  //     _db.Entry(product).State = EntityState.Modified;
  //     _db.SaveChanges();
  //     return RedirectToAction("Index");
  //   }
  }
}