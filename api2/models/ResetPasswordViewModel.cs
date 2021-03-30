using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api2.models
{
  
        public class ResetPasswordViewModel
        {
            [Required]
            public string Token { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
          
            public string NewPassword { get; set; }

            [Required]
          
            public string ConfirmPassword { get; set; }
        
    }
}
