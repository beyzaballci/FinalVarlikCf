using FinalVarlikCf.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Company
{
    [Key]
    public int Id { get; set; }

    [MaxLength(32)]
    [Required]
    public string Name { get; set; }

    
    // Navigation property (opsiyonel, eğer Asset'ler buradan erişilecekse)
    //Lazy,cascade
    //bunlarda lazy mi yoksa eager mi belirleyelim listeli ilişkilerde
     public virtual ICollection<Asset> Assets { get; set; }
    public virtual ICollection<AssetSlip>  AssetSlips { get; set; }
}
