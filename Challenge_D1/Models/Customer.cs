using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge_D1.Models
{
    public class Customer
    {
        public int    Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Cel { get; set; }
        public string OtherPhone { get; set; }
        public string Address { get; set; }
        public string OtherAddress { get; set; }
        public string Fone { get; set; }
        public string LinkFacebook { get; set; }
        public string LinkLinkedin { get; set; }
        public string LinkTwitter { get; set; }
        public string LinkInstagram { get; set; }
    }
}