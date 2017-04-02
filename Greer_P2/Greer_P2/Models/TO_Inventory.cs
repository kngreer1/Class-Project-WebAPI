using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Greer_P2.Models
{
    public class TO_Inventory
    {
        public string fldProductSKU { get; set; }
        public Nullable<int> fldCatagoryID { get; set; }
        public string fldProductName { get; set; }
        public string fldProductDescription { get; set; }
        public Nullable<decimal> fldProductPrice { get; set; }
        public string fldProductImageFile { get; set; }
    }
}