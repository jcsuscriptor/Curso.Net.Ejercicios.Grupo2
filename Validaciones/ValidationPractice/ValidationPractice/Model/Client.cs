using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationPractice.Model
{
    public class Client
    {
        public int Id { get; set; }


        [Display(Description ="Nombre")]
        public string Name { get; set; }

        public string LastName { get; set; }
        public decimal Discount { get; set; }

        public Address Address { get; set; }

       
    }


    public class Address {

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string Reference { get; set; }

    }
}
