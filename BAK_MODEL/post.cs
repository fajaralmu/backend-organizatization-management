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
    public partial class post : Main.Dto.BaseEntity
    {
        [Column]
        public string name { get; set; }
        [Column]
        public string body { get; set; }
        [Column]
        public Nullable<int> post_id { get; set; }
        [Column]
        public int user_id { get; set; }
        [Column]
        public Nullable<int> type { get; set; }
        [Column]
        public Nullable<System.DateTime> date { get; set; }
        [Column]
        public Nullable<System.DateTime> created_date { get; set; }

        [Id]
        [Column]
        public int id { get; set; }

        public string title { get; set; }
        [JoinColumn(Name = "user_id", Converter = "name")] 
        public virtual user user { get; set; }
    }
}