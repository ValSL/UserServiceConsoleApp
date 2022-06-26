using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserServiceConsoleApp.Models
{
    public class JsonPatchStandart
    {
        public int operationType { get; set; }
        public string path { get; set; }
        public string op { get; set; }
        public string from { get; set; }
        public string value { get; set; }
    }
}
