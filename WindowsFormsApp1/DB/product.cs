//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> quantity { get; set; }
        public string notes { get; set; }
        public string image { get; set; }
        public Nullable<int> categotyid { get; set; }
    
        public virtual category category { get; set; }
    }
}
