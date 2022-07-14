using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClientMakup.Model
{
    public class ExcelSettings
    {
        public int rowStartHeader { get; set; }
        public int rowDataStart { get; set; }
        public int[] columnsUser { get; set; }
        public int[] columnsUserAttributes { get; set; }
    }
}
