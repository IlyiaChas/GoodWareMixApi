using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoodWareMixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetFileController : ControllerBase
    {
        // GET: api/<GetFileController>
        [HttpGet]
        public List<string> Get()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\admin\source\repos\GoodWareMixApi\GoodWareMixApi\wwwroot\FilesSupplier\testDataIlya.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                List<string> fields1 = new List<string>();
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        //TODO: Process field
                        fields1.Add(field);
                    }
                }
               
                return fields1;
                
            }
        }

      
    }
}
