﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CozyCo.Domain.Models
{
    public class PropertyType
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
