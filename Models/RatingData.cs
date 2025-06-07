using Microsoft.ML.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


public class RatingData
{
    [LoadColumn(0)]
    public string UserId { get; set; }

    [LoadColumn(1)]
    public string ProductId { get; set; }

    [LoadColumn(2)]
    public float Label { get; set; }
}

public class ProductPrediction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ProductId { get; set; }
    public float Score { get; set; }
}