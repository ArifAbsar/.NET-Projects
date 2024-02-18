using Login.DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class login
    {
        [Required]
        public string Uname { get; set; }
        [Required]
        public string Pass { get; set; }
       
    }
}