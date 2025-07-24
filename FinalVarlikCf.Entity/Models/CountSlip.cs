using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CountSlip
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("CountPlan")]
    public int CountPlanId { get; set; }

    [ForeignKey("Location")]
    public int LocationId { get; set; }

    public int ResponsibleId { get; set; }

    public DateTime SlipDate { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    public int Status { get; set; } // 0 - Taslak, 1 - Onaylı, 9 - İptal

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

   
    
    
    
    // Navigation Properties
   
    public virtual CountPlan CountPlan { get; set; }
     public virtual Location Location { get; set; }

    //public virtual CountTran CountTran { get; set; }
    public virtual ICollection<CountTran> CountTrans { get; set; }


}
