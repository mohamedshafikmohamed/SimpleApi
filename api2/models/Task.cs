using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
    public class Task
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        [Required]
        public int Index { get; set; }
        
        public string Title { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Priority { get; set; }
    }
}
