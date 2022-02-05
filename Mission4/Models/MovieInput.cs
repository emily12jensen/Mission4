using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieInput
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        //build foreign key relationship
        [Required(ErrorMessage = "You must enter a Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }


        [Required (ErrorMessage ="You must enter a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "You must enter a Year")]
        public int Year { get; set; }
        [Required(ErrorMessage = "You must enter a Director")]
        public string Director { get; set; }
        [Required(ErrorMessage = "You must enter a Rating")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25)]
        public string  Notes { get; set; }
    }
}
