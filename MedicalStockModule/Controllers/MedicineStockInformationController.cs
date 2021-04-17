using MedicineStockModule.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using log4net;

namespace MedicineStockModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicineStockInformationController : Controller
    {
        //creating provider layer interface object
        private readonly IMedicineStockProvider iMedicineStock;
        private readonly ILog _log = LogManager.GetLogger(typeof(MedicineStockInformationController));
        public MedicineStockInformationController(IMedicineStockProvider iMedicineStock)
        {
            this.iMedicineStock = iMedicineStock;
        }

        //hhtp get method to get all the medicine stock list 
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var res =iMedicineStock.GetMedicineStock();
                
                if (res != null)
                {
                    _log.Info("Medicine Stock Retrived");
                    return Ok(res.ToList());
                }
                _log.Info("No details retrieved");
                return Content("No such details found please try again.");
            }
            catch(Exception e)
            {
                _log.Error("Excpetion:" + e.Message + " has occurred while trying to retrieve stock info.");
                return Content("The following exception has occurred while retreving the stock." + e.Message + " Please try again");
            }
        }
    }
}
