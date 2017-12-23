using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductPages.Common.Models
{

    public class ProductPage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string NameOfProduct { get; set; }
        public string MaintainerOfProduct { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<ImageUrl> ImageUrls { get; set; }
        public ProductPageType TypeOfProduct { get; set; }

        public string AboutTheProduct { get; set; }
        public string ProductManager { get; set; }
        public string ProductOwner { get; set; }
        public string ProductSetDate { get; set; }
        public string ApplicationTechnology { get; set; }
        public string Description { get; set; }



        public string SystemDocumentationUrl { get; set; }
        public string TeamCityProjectUrl { get; set; }
        public string OctopusDeployProjectUrl { get; set; }
        
 

        public ProductPage() { }
    }
}
