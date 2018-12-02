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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentList"></param>
        /// <param name="registerList"></param>
        /// <returns></returns>
        public ResultModel<List<string>> SearchProcess(List<string> contentList, List<string> registerList)
        {
            var result = new ResultModel<List<string>>();
            try
            {
                result = new ResultModel<List<string>>() { Success = true, Data = Process(contentList, registerList) };
            }
            catch (Exception e)
            {
                _loggerService.LogError(e.Message);
                result = new ResultModel<List<string>>() { Success = false, Data = new List<string>() { e.Message } };
            }
            return result;
        }
        /// <summary>
        /// Method that searches for each Line of the register List, comparing each character to the content tList. 
        /// Saves the validation result on a new List dataResult for the return value.
        /// </summary>
        /// <param name="contentList">List of characters</param>
        /// <param name="registerList">List of names</param>
        /// <returns>List of data with the results</returns>
        private List<string> Process(List<string> contentList, List<string> registerList)
        {
            try
            {
                // List to save the results
                var dataResult = new List<String>();
                //Process to find the letters
                registerList.ForEach(x =>
                {
                // flag to determinte if the name exists
                bool bandFound = false;
                // Clone the list of contentList, the idea is to erase the element from the list if it is found
                List<string> contentListCopy = contentList.ToList();
                // Iterate on the name's characters 
                foreach (char letter in x)
                    {
                    // Temporal variable to save the character if it is found
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
                        // character found! let's remove it from the content list, 
                        // so the character doesn't repeat in the search
                        contentListCopy.Remove(letterFound);
                        }
                        else
                        // Finish the cycle, letter not found
                        break;
                    }
                // Word complete in contentList
                if (bandFound)
                        dataResult.Add(x + "->Si existe");
                    else
                        dataResult.Add(x + "->No existe");
                });
                if (dataResult.Count == 0)
                    dataResult.Add("No data");
                return dataResult;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message);
                throw new Exception("Process",ex);
            }
        }
    }
}
