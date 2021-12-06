//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Web;

//namespace MyProject_01.Models
//{
//    public partial class ProductMasterData
//    {
        
//        public int Id { get; set; }
//        [Required]
//        public string Name { get; set; }
//        public string Avatar { get; set; }
//        public Nullable<int> CategoryId { get; set; }
//        public string ShortDes { get; set; }
//        public string FullDes { get; set; }
//        public Nullable<double> Price { get; set; }
//        [NotMapped]
//        public System.Web.HttpPostedFileBase ImageUpLoad1 { get; set; }

//    }
//}