using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Greer_P2.Models;

namespace Greer_P2.Controllers
{
    public class ProductsInCategoryController : ApiController
    {
        private Project_4Entities db = new Project_4Entities();

        [Route("api/categories")]
        public List<TO_Category> GetAllCategories()
        {
            List<TO_Category> categories = new List<TO_Category>();

            foreach(tblCategory category in db.tblCategories)
            {
                TO_Category categoryObject = new TO_Category();
                categoryObject.fldCatagoryID = category.fldCatagoryID;
                categoryObject.fldCatagoryName = category.fldCatagoryName;

                categories.Add(categoryObject);
            }
            var sortedList = categories
                .OrderBy(m => m.fldCatagoryName)
                .ToList();

            return sortedList;
        }
        [Route("api/categories/{categoryID}")]
        public List<TO_Inventory> GetIndividualCategory(int categoryID)
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
                .Where(m => m.fldCatagoryID == categoryID)
                .OrderBy(m => m.fldProductName)
                .ToList();

            return selectedInventoryObject;
        }
    }
}
