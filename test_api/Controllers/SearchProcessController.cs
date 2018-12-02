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
        /// <summary>
        /// Class constructor, implements dependency injection for the searchProcess interface
        /// </summary>
        /// <param name="searchProcess"></param>
        public SearchProcessController(ISearchProcess searchProcess)
        {
            _searchProcess = searchProcess;
        }

        //// GET api/SearchProcess
        [HttpPost]
        public string Post([FromBody]ProcessRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }
                // Use helper to split the content of the request parameters
                List<string> contentList = SplitTextHelper.splitStringLines('\n', request.content.Trim());
                List<string> registerList = SplitTextHelper.splitStringLines('\n', request.register.Trim());
                var res = ModelState.IsValid ? _searchProcess.SearchProcess(contentList, registerList) : new ResultModel<List<string>>() { Success = false };
                return JsonConvert.SerializeObject(res);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new ResultModel<List<string>>() { Success = false, Data = new List<string>() { ex.Message } });
            }
        }
    }
}
