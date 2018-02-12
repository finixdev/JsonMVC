using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JsonMVC.Models
{
    public class NewJsonItem
    {
        [Required]
        public string Data { get; set; }
    }
}
