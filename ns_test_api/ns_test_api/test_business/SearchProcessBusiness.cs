using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_models.contracts;
using test_models.models;
using test_utils.contracts;

namespace test_business
{
    public class SearchProcessBusiness : ISearchProcess
    {
        private ILoggerService _loggerService;

        public SearchProcessBusiness(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public ResultModel<List<string>> SearchProcess(List<string> contentList, List<string> registerList)
        {

            // Dummy
            
            //contentList = new List<string>(new string[] { "T", "Z", "E", "C", "A", "H", "L", "M", "O", "F", "O", "U", "E", "B", "Y", "O", "P", "D", "R", "B", "A", "A", "D", "I", "L", "N", "G", "D", "U", "E", "K", "W", "A", "T", "Z", "L", "O", "T", "T", "O", "N", "T", "U", "T" });
            //registerList = new List<string>(new string[] { "VOLOTEA", "POBEDA", "COBALT", "VUELING", "CONSILIUM" });

            var result = new ResultModel<List<string>>();
            try
            {
                result = new ResultModel<List<string>>() { Success = true, Data = Process(contentList, registerList) };
            }
            catch (Exception e)
            {
                _loggerService.LogError(e.Message);
                result = new ResultModel<List<string>>() { Success = false };
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentList"></param>
        /// <param name="registerList"></param>
        /// <returns></returns>
        private List<string> Process(List<string> contentList, List<string> registerList)
        {
            //Process
            var dataResult = new List<String>();

            //Process to find the letters
            registerList.ForEach(x =>
            {
                bool bandFound = false;
                // Clone the list of contentList
                List<string> contentListCopy = contentList.ToList();
                foreach (char letter in x)
                {
                    // Variable 
                    string letterFound = string.Empty;
                    foreach (var letterContent in contentListCopy)
                    {
                        if (letterContent.Equals(letter.ToString()))
                        {
                            letterFound = letterContent;
                            bandFound = true;
                            break;
                        }
                    }
                    if (!string.IsNullOrEmpty(letterFound))
                    {
                        // Letter found!
                        contentListCopy.Remove(letterFound);
                    }
                    else
                        // Finish the cycle, letter not found
                        break;
                }
                // Word complete in contentList
                if (bandFound)
                    dataResult.Add(x);
            });
            if (dataResult.Count == 0)
                dataResult.Add("No data");
            return dataResult;
        }
    }
}
