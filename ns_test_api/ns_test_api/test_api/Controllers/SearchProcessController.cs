using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using er = System.Web.Mvc;
using test_models.contracts;
using test_models.models;
using test_api.helpelrs;

namespace test_api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SearchProcessController : ApiController
    {
        private ISearchProcess _searchProcess;

        public SearchProcessController(ISearchProcess searchProcess)
        {
            _searchProcess = searchProcess;
        }

        // GET api/SearchProcess
        public string Get()
        {
            var contentList = new List<string>();
            contentList.Add("a");
            contentList.Add("b");
            contentList.Add("c");
            var registerList = new List<string>();
            contentList.Add("abc");
            contentList.Add("def");
            contentList.Add("ghi");

            var res = _searchProcess.SearchProcess(contentList, registerList);
            return JsonConvert.SerializeObject(res);
        }

        [HttpPost]
        public string Post([FromBody]ProcessRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }
                List<string> contentList = SplitTextHelpler.splitStringLines('\n', request.content.Trim());
                List<string> registerList = SplitTextHelpler.splitStringLines('\n', request.register.Trim());                
                var res = ModelState.IsValid ? _searchProcess.SearchProcess(contentList, registerList) : new ResultModel<List<string>>() { Success = false };
                return JsonConvert.SerializeObject(res);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject( new ResultModel<List<string>>() { Success = false, Data = new List<string>() { ex.Message } });
            }
        }
    }
}
