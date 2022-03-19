using System;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Category
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "Приоритет должен быть больше нуля.")]
        public int DisplayOrder { get; set; }

        [Required]
        public string? Text { get; set; }

        
        public string? Time { get; set; }
    }


}
