using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace FinalVarlikCf.Models
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public int Status { get; set; }

        public int OwnershipType { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
        //public int? LocationId { get; set; } eğer setNull yapılırsa Contextte bu şekilde olmalı


        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("AssetGroup")]
        public int AssetGroupId { get; set; }

        

        [MaxLength(32)]
        public string SerialNumber { get; set; }

        [MaxLength(32)]
        public string KmoCode { get; set; }

        [MaxLength(12)]
        public string SapCode { get; set; }

        [MaxLength(32)]
        public string BarCode { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        [MaxLength(32)]
        public string Brand { get; set; }

        [MaxLength(32)]
        public string Model { get; set; }

        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Length { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Area { get; set; }

        [MaxLength(24)]
        public string Power { get; set; }

        [MaxLength(32)]
        public string Color { get; set; }

        public int? ProductionYear { get; set; }

        [Column(TypeName = "decimal(12,6)")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "decimal(12,6)")]
        public decimal? Longitude { get; set; }


        //bunlar seni LINQ tarafında rahatlatır. Yani Entity Framework’e “bu foreign key hangi nesneye karşılık geliyor”
        //demiş olursun.
        //navigation property
       
        //NOTTT !!! Default Cconvention yönteminde bire çok ilişkiyi kurarken foreign key kolonuna karşılık gelen bir property tanımlamak mecburiyetinde değilizdir.
        //Eğer tanımlamazsak EF Core kendisi tamamlayacak yok eğer tamamlamazsak, tanımladığımızı baz alacaktır.
        
        //Default convention yönteminde foreign key kolonuna karşılık gelen property'i tanımladığımızda bu property ismi temel geleneksel entity tnımlma kurallarına 
        //uymuyorsa eğer data Annotations'lar ile müdahalede bulunabiliriz

        public virtual Company Company { get; set; }
        public virtual Location Location { get; set; }
        public virtual Department Department { get; set; }
        public virtual AssetGroup AssetGroup { get; set; }
        public virtual ICollection<AssetDoc> AssetDocs { get; set; }// her zaman lazy olmalı
        public virtual ICollection<AssetLog> AssetLogs { get; set; }
        public virtual ICollection<CountTran> CountTrans { get; set; }
        public virtual ICollection<AssetTransaction> AssetTransactions { get; set; }









    }
}


     