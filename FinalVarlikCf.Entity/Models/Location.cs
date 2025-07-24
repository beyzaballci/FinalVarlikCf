using FinalVarlikCf.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Location
{
    [Key]
    public int Id { get; set; }

    [MaxLength(32)]
    [Required]
    public string Name { get; set; }

    public int Level { get; set; } // 0 -> 1 -> 2 -> 3 şeklinde hiyerarşi

    public int? ParentId { get; set; }

    
    //Navigation property
    public virtual ICollection<Asset> Assets { get; set; }
    public virtual ICollection<CountSlip>CountSlips { get; set; }
    public virtual ICollection<CountPlan> CountPlans { get; set; }



}
