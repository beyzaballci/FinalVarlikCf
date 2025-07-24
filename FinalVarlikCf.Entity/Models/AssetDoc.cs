namespace FinalVarlikCf.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AssetDoc
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; } 

        [MaxLength(5)]
        public string FileType { get; set; } 

        public virtual int DocType { get; set; }// virtual özelliği burada kullanılıyor mu emin değilim 

       

        // Navigation Property; bir entity'nin başka bir entity ile olan ilişkisini kod seviyesinde ifade eden bir özelliktir.
        //lazy yapısını nerede net olarak kullanmamız gerekiyor?
        public virtual Asset Asset { get; set; }
       
    }

}
