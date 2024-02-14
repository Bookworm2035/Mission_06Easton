using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
namespace Mission_06Easton.Models
{
    public class Movies
    {
        [Key]
        [Required]
        //all the database stuff
        public int MovieID { get; set;}
        //add the rest
        public string Category { get; set; }
        public string Subcategory { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Director { get; set; }

        public string Rating { get; set; }

        public Boolean Edited { get; set; }

        public string LentTo { get; set; }

        public string Notes { get; set; }

    }

}


//this is the database model set up
//