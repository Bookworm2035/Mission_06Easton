using System.ComponentModel.DataAnnotations;
namespace Mission_06Easton.Models
{
    public class Cateogry
        //make it required and the ID key
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        //get category name
        [Required]
        public string CategoryName { get; set; }

    }
}
