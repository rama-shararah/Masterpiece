//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterPieceMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Subscription
    {
        public int Subscription_Id { get; set; }
        [Display(Name = "Duration")]
        public Nullable<int> Subscription_Duration { get; set; }
        [Display(Name = "Begging date")]
        public Nullable<System.DateTime> Subscription_Beg { get; set; }
        [Display(Name = "Ending date")]
        public Nullable<System.DateTime> Subscription_End { get; set; }
        public Nullable<int> Activation_code { get; set; }
        [Display(Name = "Amount")]
        public Nullable<decimal> Subscription_Amount { get; set; }
        public string userId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
