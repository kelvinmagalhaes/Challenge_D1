namespace WebApplication7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Definitions for the Phone table
    /// </summary>
    [Table("Phone")]
    public partial class Phone
    {
        [Key]
        public int IDPhone { get; set; }

        [StringLength(450)]
        public string CPFCustomer { get; set; }

        public string NamePhone { get; set; }

        public string PhoneNumber { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
