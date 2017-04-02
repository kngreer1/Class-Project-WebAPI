using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Greer_P2.Models;

namespace Greer_P2.Controllers
{
    public class SingleProductController : ApiController
    {
        private Project_4Entities db = new Project_4Entities();

        [Route("api/inventory")]
        public List<TO_Inventory> GetAllInventory()
        {
            List<TO_Inventory> inventories = new List<TO_Inventory>();

            foreach(tblInventory inventory in db.tblInventories)
            {
                TO_Inventory inventoryObject = new TO_Inventory();
                inventoryObject.fldCatagoryID = inventory.fldCatagoryID;
                inventoryObject.fldProductDescription = inventory.fldProductDescription;
                inventoryObject.fldProductImageFile = inventory.fldProductImageFile;
                inventoryObject.fldProductName = inventory.fldProductName;
                inventoryObject.fldProductPrice = inventory.fldProductPrice;
                inventoryObject.fldProductSKU = inventory.fldProductSKU;

                inventories.Add(inventoryObject);
            }
            var sortedList = inventories
                            .OrderBy(m => m.fldProductName)
                            .ToList();

            return sortedList;
        }
        [Route("api/inventory/{productSKU}")]
        public List<TO_Inventory> GetIndividualInventory(string productSKU)
        {
            List<TO_Inventory> inventories = new List<TO_Inventory>();

            foreach (tblInventory inventory in db.tblInventories)
            {
                TO_Inventory inventoryObject = new TO_Inventory();
                inventoryObject.fldCatagoryID = inventory.fldCatagoryID;
                inventoryObject.fldProductDescription = inventory.fldProductDescription;
                inventoryObject.fldProductImageFile = inventory.fldProductImageFile;
                inventoryObject.fldProductName = inventory.fldProductName;
                inventoryObject.fldProductPrice = inventory.fldProductPrice;
                inventoryObject.fldProductSKU = inventory.fldProductSKU;

                inventories.Add(inventoryObject);
            }
            var selectedInventoryObject = inventories
                            .Where(m => m.fldProductSKU == productSKU)
                            .OrderBy(m => m.fldProductName)
                            .ToList();
                           

            return selectedInventoryObject;
        }
    }
}
