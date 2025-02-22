using NewsAPI.Models;

namespace theParodyJournal.Models
{
    public class NewsViewModel
    {
        public List<Article> Articles { get; set; }
        public string SearchQuery { get; set; }
    }
}