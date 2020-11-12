using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AR;
using LSDistribution.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace LSDistribution.Controllers
{
    public class WarehouseController : Controller
    {
        [Route("/Warehouse/{id}")]
        public IActionResult Index(int id)
        {
            var wh = Warehouse.GetWarehouse(id);
            if (wh == null)
                return View("Error", "Warehouse with given id not found!");

            return View(wh);
        }
        [HttpPost]
        [Route("/Warehouse/Update")]
        public async Task<IActionResult> Update(Warehouse wh)
        {
            return await Task.Run(() =>
            {
                try
                {
                    wh.DBUpdate();
                    return Ok();
                }
                catch (Exception ex)
                {
                    ARDebug.Log(ex.ToString());
                    return StatusCode(500);
                }
            });
        }

        [HttpPost]
        [Route("/Warehosue/Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    Warehouse wh = Warehouse.GetWarehouse(id);

                    if (wh == null)
                    {
                        ARDebug.Log("Warehouse with given ID not found. ID: " + id);
                        return StatusCode(500);
                    }
                    else
                    {
                        wh.DBRemove();
                        return Ok();
                    }
                }
                catch(Exception ex)
                {
                    ARDebug.Log(ex.ToString());
                    return StatusCode(500);
                }
            });
        }
    }
}
