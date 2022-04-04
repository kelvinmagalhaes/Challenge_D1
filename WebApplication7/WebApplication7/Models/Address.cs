namespace WebApplication7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    /// <summary>
    /// Definitions for the Address table
    /// </summary>
    [Table("Address")]
    public partial class Address
    {
        [Key]
        public int IDAddress { get; set; }

        [StringLength(450)]
        public string CPFCustomer { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string MoreInfo { get; set; }

        public string NameAddress { get; set; }

        public int Number { get; set; }

        public string PostalCode { get; set; }

        public string Region { get; set; }

        public string Street { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
