//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Näytevarasto
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public int OrderID { get; set; }
        public Nullable<System.DateTime> Orderdate { get; set; }
        public Nullable<long> CompanyID { get; set; }
        public Nullable<long> ISBN { get; set; }
        public string BookName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> IsInCart { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public Nullable<bool> SentToJvs { get; set; }
    }
}
