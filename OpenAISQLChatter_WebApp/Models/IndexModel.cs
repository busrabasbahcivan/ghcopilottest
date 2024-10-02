using Azure.AI.OpenAI;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Microsoft.Identity.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OpenAIWebApp.Models
{
    public class IndexModel // : PageModel
    {
        public IndexData _indexData = new IndexData();
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _indexData = new IndexData();
            _indexData.Question = "";
            _indexData.Summary = "";
            _indexData.Query = "";
            _indexData.IsQuery = "";
            _indexData.Error = "";
            _indexData.TimeElapsed = "";
            _indexData.RowData = new List<List<string>>();
        }

        public IndexModel(IndexData data)
        {
            _indexData.Question = data.Question;
            _indexData.Summary = data.Summary;
            _indexData.Query = data.Query;
            _indexData.IsQuery = data.IsQuery;
            _indexData.Error = data.Error;
            _indexData.TimeElapsed = data.TimeElapsed;
            _indexData.RowData = data.RowData;

        }
        // Parameterless constructor
        public IndexModel()
        {
            // IndexData.Question = IndexData.Question + " ";
        }

        // Constructor that takes arguments
        public IndexModel(string question,
            string summary,
            string query,
            string isQuery,
            string error,
            string timeElapsed,
            List<List<string>> data
            )
        {
            _indexData.Question = question;
            _indexData.Summary = summary;
            _indexData.TimeElapsed = timeElapsed;
            _indexData.Query = query;
            _indexData.IsQuery = isQuery;
            _indexData.Error = error;
            _indexData.RowData = data;
        }
    }

    public class IndexData
    {
        public List<string> QuestionHistory { get; set; } = new List<string>();
        public string Question { get; set; }
        public string Summary { get; set; }
        public string Query { get; set; }
        public string IsQuery { get; set; }
        public string TimeElapsed { get; set; }
        public string Error { get; set; }
        public List<List<string>> RowData { get; set; }
    }

    public class AIQuery
    {
        public string summary { get; set; } = string.Empty;
        public string query { get; set; } = string.Empty;
        public string isQuery { get; set; } = string.Empty;
    }
}
