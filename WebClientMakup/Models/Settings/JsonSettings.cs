using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WebClientMakup.Model
{
    public class JsonSettings : XMLSupplierConfig
    {
        public string urlImage { get; set; }
        public string nameFeature { get; set; }
        public string urlDocument { get; set; }
    }
}
