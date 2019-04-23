using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace CozyCo.Models
{
    //Residental properties
    public class Property
    {
        public int ID { get; set; }
        public string Address { get; set; }
        [Display(Name = "Address Continuation.")]
        public string Address2 { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public string Image { get; set; }

    }
}
