using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_models.models
{
    public class ProcessRequest
    {
        [Required]
        public string content { get; set; }
        [Required]
        public string register { get; set; }
    }
}
