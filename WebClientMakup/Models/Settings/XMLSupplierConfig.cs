using WebClientMakup.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebClientMakup.Model
{
    public class XMLSupplierConfig
    {
        public string Input { get; set; }
        //public string InternalCode { get; set; } 
        public string SupplierId { get; set; }
        public string Title { get; set; }
        public string TitleLong { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public string VendorId { get; set; }
        // public string CategoriesId { get; set; }
        public string DocumentsStart { get; set; }
        public DocumentConfig Documents { get; set; }
        public string Images { get; set; }
        public string Image360 { get; set; }
        //public BasicСharacteristic BasicСharacteristic { get; set; }
        public string AttributesStart { get; set; }
        public string CategoriesProduct { get; set; }
        public List<ProductAttributeKey> productAttributeKeys { get; set; }
        public ProductAttributesBuf AttributesParam { get; set; }
        public string PackagesStart { get; set; }
        public SupplierConfigPackage Packages { get; set; }
        public string Features { get; set; }
        public string CategoriesStart { get; set; }

        public List<CategoryEntity> Categories { get; set; }

    }
}
