using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
    public class Project
    {

        public int Id { get; set; }
        [Required]
        public int BoardId { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
        public string Title { get; set; }
        [EmailAddress]
        [Required]
        public string CreatedBy { get; set; }
       
        public string Description { get; set; }
       
    }
}
