using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AssetSlip
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Company")]
    public int CompanyId { get; set; }

    public DateTime SlipDate { get; set; }

    public int SlipType { get; set; } // 10, 11, 20, 21, 30, 31

    public int Transsign { get; set; } // -1, 0, 1

    public int TransType { get; set; } // Satın alma, Kiralama, Hibe, vb.

    public int TargetId { get; set; }
   

    [MaxLength(1000)]
    public string Description { get; set; }

    public int Status { get; set; } // 0 - Taslak, 1 - Onaylı, 9 - İptal

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

   
    // Navigation Property
     public virtual Company Company { get; set; }
    public virtual ICollection<AssetTransaction> AssetTransactions { get; set; }

}
