using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonMVC.Models
{
    public class JsonViewModel
    {
        public IEnumerable<JsonItem> Items { get; set; }
    }
}
