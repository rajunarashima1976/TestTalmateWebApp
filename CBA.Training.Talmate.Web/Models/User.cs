﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CBA.Training.Talmate.Web.Models
{
    public class User
    {            
        [Required]
        public string Username { get; set; }   
        [Required]
        public string Password { get; set; }
       
    }
}
