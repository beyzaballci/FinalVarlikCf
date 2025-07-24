using FinalVarlikCf.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Department
{
    [Key]
    public int Id { get; set; }

    [MaxLength(32)]
    [Required]
    public string Name { get; set; }

    // Navigation property (opsiyonel)
    //buna çok da gerek yokmuş, asset kısmında daha önemli
     public virtual ICollection<Asset> Assets { get; set;} // lazy yapısına dönüştürdük burda tüm assetler gelmesin diye
}
