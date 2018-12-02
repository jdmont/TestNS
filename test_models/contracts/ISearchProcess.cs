using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_models.models;

namespace test_models.contracts
{
    public interface ISearchProcess
    {
        ResultModel<List<string>> SearchProcess(List<string> contentList, List<string> registerList);
    }
}
