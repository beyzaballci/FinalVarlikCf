using FinalVarlikCf.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AssetTransaction
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("AssetSlip")]
    public int SlipId { get; set; }

    [ForeignKey("Asset")]
    public int AssetId { get; set; }

   
    // Navigation properties
     public virtual AssetSlip AssetSlip { get; set; }
     public virtual Asset Asset { get; set; }

}
