//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pantra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MyShop
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Nullable<int> Floor { get; set; }
    
        public virtual Floor Floor1 { get; set; }
    }
}