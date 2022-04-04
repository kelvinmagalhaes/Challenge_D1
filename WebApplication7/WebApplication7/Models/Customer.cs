namespace WebApplication7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Definitions for the Customer table
    /// </summary>
    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Addresses = new HashSet<Address>();
            Phones = new HashSet<Phone>();
        }

        [Key]
        [StringLength(450)]
        public string CPF { get; set; }

        public string Date { get; set; }

        public int Id { get; set; }

        public string LinkFacebook { get; set; }

        public string LinkInstagram { get; set; }

        public string LinkLinkedin { get; set; }

        public string LinkTwitter { get; set; }

        public string Name { get; set; }

        public string RG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
