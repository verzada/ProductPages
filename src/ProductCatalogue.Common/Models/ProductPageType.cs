using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductPages.Common.Models
{
  public class ProductPageType
  {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      public string TypeOfProduct { get; set; }

      public ProductPageType() { }
  }
}
