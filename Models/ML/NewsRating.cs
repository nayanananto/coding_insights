using Microsoft.ML.Data;

public class NewsRating
{
    [ColumnName("UserId"),LoadColumn(0)]
    public float UserId { get; set; }

    [LoadColumn(1)]
    public string ArticleTag { get; set; }

    [LoadColumn(2)]
    public float Score { get; set; }
}
