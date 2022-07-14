using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebClientMakup.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClientMakup.Model.Entity;

namespace WebClientMakup.Model
{
    public class ProFileSupplier
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }

        public string Connection { get; set; }

        public string SupplierName { get; set; }
        public string Source { get; set; }
        public SourceSettings SourceSettings { get; set; }
        public string Type { get; set; }

        public XMLSupplierConfig XMLSupplierConf { get; set; }

        public JsonSettings JsonSettings { get; set; }

        public ExcelSettings ExcelSettings { get; set; }

    }
}
