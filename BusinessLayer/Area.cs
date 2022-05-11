﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Area
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public IList<User> Users { get; set; }
        
    }
}
