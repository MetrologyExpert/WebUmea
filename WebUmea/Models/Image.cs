using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;



namespace WebUmea.Models
{
    public class Image
    {   
        [Key]
        public int ImageID { get; set; }
        
        [StringLength(255)]
        public string Title { get; set; }

        [DisplayName("Upload File")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}