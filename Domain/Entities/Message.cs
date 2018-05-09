namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Message()
        {
            UsersMessages = new HashSet<UsersMessage>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public int Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public int? Answer { get; set; }

        public int PublicOrPrivate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersMessage> UsersMessages { get; set; }
    }
}
