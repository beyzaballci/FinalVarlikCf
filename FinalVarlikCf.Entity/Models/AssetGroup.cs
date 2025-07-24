using FinalVarlikCf.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AssetGroup
{
    [Key]
    public int Id { get; set; }

    [MaxLength(32)]
    [Required]
    public string Name { get; set; }

    public int Level { get; set; } 

    public int? ParentId { get; set; }

    
    //[ForeignKey("ParentId")]
    //public AssetGroup Parent { get; set; }
    public virtual ICollection<Asset> Assets { get; set; }
   

}
