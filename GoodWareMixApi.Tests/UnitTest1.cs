using FakeItEasy;
using GoodWareMixApi.Controllers;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Net;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GoodWareMixApi.Service;
using GoodWareMixApi.Filter;
using Microsoft.AspNetCore.Mvc;
using Moq;
using GoodWareMixApi.Interfaces;
using System.Threading.Tasks;
using GoodWareMixApi.Model;
using System.Collections.Generic;
using System;

namespace GoodWareMixApi.Tests
{
    public class UnitTest1
    {
        private readonly HttpClient _client;

        ParserDocuments documentService = new ParserDocuments();
        private readonly IUriService uriService;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment environment;
        private readonly ILogger<ProductController> _logger;
        ProductController _productController;

        public UnitTest1()
        {
            Connection.context = new MongoDBService("WebApiDatabase");

         
           
        }
        //[Fact]
        //public async void Get_Product_By_Id_622f3c4e6c4bd682c61995be()
        //{
        //    var repositoryMock = new Mock<IProductRepository>();
        //    var product = new Product();
        //    repositoryMock.Setup(r => r.GetProductById("622f3c4e6c4bd682c61995be")).Returns(Task.FromResult(product));

        //    var controller = new ProductController(uriService, environment, _logger, repositoryMock.Object);

        //    var result = await controller.GetProductById("622f3c4e6c4bd682c61995be");
        //    Assert.Equal(product, result);
        //}
     
    }
}