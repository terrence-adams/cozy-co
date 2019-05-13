using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace CozyCo.Domain.Models
{
    //Residental properties
    public class Property
    {
        public int ID { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [Display(Name = "Address Continuation.")]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(10)]
        public string Zipcode { get; set; }

        public string Image { get; set; }

        public int PropertyTypeId { get; set; }

        public PropertyType PropertyType { get; set; }

    }
}
