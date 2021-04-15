using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
    public class Messages
    {
        public int Id { get; set; }
  
        public string Message { get; set; }
        [Required]
        public string Sender_Id { get; set; }
        [Required]
        public string Resever_Id { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string ChatId { get; set; }

    }
}
