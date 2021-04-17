using log4net;
using MedicineStockModule.Models;
using MedicineStockModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStockModule.Providers
{
    public class MedicineStockProvider : IMedicineStockProvider
    {
        private readonly IMedicineStockRepository IMedicineStock;

        private readonly ILog _log = LogManager.GetLogger(typeof(MedicineStockProvider));
        public MedicineStockProvider(IMedicineStockRepository IMedicineStock)
        {
            this.IMedicineStock = IMedicineStock;
        }
        public IEnumerable<MedicineStockDTO> GetMedicineStock()
        {
            _log.Info("Medicine Stock requested");
            var MedicineStockList = IMedicineStock.GetAll();
            _log.Info("Medicine Stock Retrived");
            return MedicineStockList.ToList();

        }
    }
}
