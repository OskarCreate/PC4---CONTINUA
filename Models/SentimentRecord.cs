using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

public class SentimentRecord
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    public string Text { get; set; }

    public bool Prediction { get; set; }

    public float Probability { get; set; }

    public float Score { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}