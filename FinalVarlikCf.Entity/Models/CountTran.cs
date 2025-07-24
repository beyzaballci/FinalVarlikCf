using FinalVarlikCf.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CountTran
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("CountSlip")]
    public int CountSlipId { get; set; }

    [ForeignKey("Asset")]
    public int AssetId { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    
    
    // Navigation Properties

    public virtual CountSlip CountSlip { get; set; }
    public virtual Asset Asset { get; set; }
    public virtual CountPlan CountPlan { get; set; }
}
