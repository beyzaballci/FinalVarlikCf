using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CountPlan
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Location")]
    public int LocationId { get; set; }

    public DateTime Plandate { get; set; }

    public int ResponsibleId { get; set; } // Kullanıcı veya personel gibi bir yapı varsa bağlanabilir

    [MaxLength(1000)]
    public string Description { get; set; }

    public int Status { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }



    // Navigation Property
     public virtual Location Location { get; set; }
    public virtual ICollection<CountTran> CountTrans { get; set; }
    public virtual ICollection<CountSlip> CountSlips { get; set; }




}
