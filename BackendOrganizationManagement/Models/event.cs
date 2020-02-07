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
    [AdditionalFilter(join= joinSql, filter =filterSql)]
    public partial class @event : Main.Dto.BaseEntity
    {

        const string joinSql = "   left join [section] ON program.sect_id = [section].id left join division on division.id = [section].division_id";
        const string filterSql = "division.id=${filterId}";


        [Column]
        public string name { get; set; }
        [Column]
        public string location { get; set; }
        [Column]
         
        public string info { get; set; }
        [Column]
        public int done { get; set; }
        [Column]
        public int participant { get; set; }
        [Column]
        public int program_id { get; set; }
        [Column]
        public int user_id { get; set; }
        [Column]
        public Nullable<System.DateTime> created_date { get; set; }
        [Column]
        public Nullable<System.DateTime> date { get; set; }
        [Id]
        [Column]
        public int id { get; set; }

        [JoinColumn(Name = "program_id", Converter = "name")]
        public virtual program program { get; set; }
    }
}
