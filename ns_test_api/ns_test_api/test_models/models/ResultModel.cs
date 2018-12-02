using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_models.models
{
    public class ResultModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
