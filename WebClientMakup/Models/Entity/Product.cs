using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClientMakup.Model
{
    public class Product
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        //[BsonRepresentation(BsonType.ObjectId)]
        public string SupplierId { get; set; }
        public string VendorId { get; set; }

        public string InternalCode { get; set; }

        public string Title { get; set; }

        public string TitleLong { get; set; }

        public string Description { get; set; }

        public string Vendor { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Documents { get; set; }

        public List<string> Images { get; set; }

        public string Image360 { get; set; }


        public List<AttributeProduct> Attributes { get; set; }

        public List<Package> Packages { get; set; }

        public List<string> Features { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }
        public bool Equals(Product person)
        {

            if (this.InternalCode != person.InternalCode ||
            this.Title != person.Title ||
            this.TitleLong != person.TitleLong ||
            this.Description != person.Description ||
            this.Vendor != person.Vendor ||
            this.SupplierId != person.SupplierId)
            {
                return false;
            }

            //if (this.Attributes != null && person.Attributes != null)
            //{
            //    if (this.Attributes.Count == person.Attributes.Count)
            //    {
            //        //for (int i = 0; i < this.Attributes.Count; i++)
            //        //{
            //        //    if (this.Attributes[i].Value != person.Attributes[i].Value ||
            //        //        this.Attributes[i].Type != person.Attributes[i].Type ||
            //        //        this.Attributes[i].Unit != person.Attributes[i].Unit)
            //        //    {
            //        //        return false;
            //        //    }
            //        //}
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
            //if (this.Documents != null && person.Documents != null)
            //{
            //    if (this.Documents.Count == person.Documents.Count)
            //    {

            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
            //if (this.Images != null && person.Images != null)
            //{
            //    if (this.Images.Count == person.Images.Count)
            //    {
            //        //for (int i = 0; i < this.Images.Count; i++)
            //        //{
            //        //    if (this.Images[i] != person.Images[i])
            //        //    {
            //        //        return false;
            //        //    }

            //        //}
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
            //if (this.Features != null && person.Features != null)
            //{
            //    if (this.Features.Count == person.Features.Count)
            //    {
            //        //for (int i = 0; i < this.Features.Count; i++)
            //        //{
            //        //    if (this.Features[i] != person.Features[i])
            //        //    {
            //        //        return false;
            //        //    }
            //        //}
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
            //if (this.Packages != null && person.Packages != null)
            //{
            //    if (this.Packages.Count == person.Packages.Count)
            //    {
            //        //for (int i = 0; i < this.Packages.Count; i++)
            //        //{
            //        //    if (this.Packages[i].Barcode != person.Packages[i].Barcode ||
            //        //        this.Packages[i].Weight != person.Packages[i].Weight ||
            //        //        this.Packages[i].PackQty != person.Packages[i].PackQty ||
            //        //        this.Packages[i].Volume != person.Packages[i].Volume
            //        //        )
            //        //    {

            //        //        return false;

            //        //    }
            //        //}

            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
            return true;

        }
    }
}
