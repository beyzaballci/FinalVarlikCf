using FinalVarlikCf.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AssetLog
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Asset")]
    public int AssetId { get; set; }

    [MaxLength(32)]
    [Required]
    public string LogType { get; set; } 

    [MaxLength(4000)]
    public string LogData { get; set; } 

    public int CreatedBy { get; set; } 

    public DateTime CreatedDate { get; set; }

    
    // Navigation Property
     public virtual Asset Asset { get; set; }
}
