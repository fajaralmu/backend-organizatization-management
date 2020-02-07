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
    using System;
    using System.Collections.Generic;
    [CustomModel]
    public partial class member:BaseEntity
    {
        [Column]
        public string name { get; set; }
        [Column]
        public string description { get; set; }
        [Column]
        public int position_id { get; set; }
        [Column]
        public Nullable<System.DateTime> created_date { get; set; }
        [Column]
        [Id]
        public int id { get; set; }
        [Column]
        public int section_id { get; set; }

        [JoinColumn(Name = "position_id", Converter = "name")]
        public virtual position position { get; set; }
        [JoinColumn(Name = "section_id", Converter = "name")]
        public virtual section section { get; set; }
    }
}
