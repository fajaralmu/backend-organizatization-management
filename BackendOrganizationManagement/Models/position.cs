//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackendOrganizationManagement.Models
{
    using Main.Dto;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    [CustomModel]
    public partial class position: BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public position()
        {
            this.members = new HashSet<member>();
        }
        [Column]
        public string name { get; set; }
        [Column]
        public Nullable<int> parent_position_id { get; set; }
        [Column]
        public Nullable<System.DateTime> created_date { get; set; }
        [Column][Id]
        public int id { get; set; }
        [Column]
        public string description { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<member> members { get; set; }
    }
}
