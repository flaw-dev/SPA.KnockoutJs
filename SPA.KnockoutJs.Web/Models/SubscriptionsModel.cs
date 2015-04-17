using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPA.KnockoutJs.Web.Models
{
    public class SubscriptionsModel
    {
        
    }
    public class Subscription
    {
        public int Amount { get; set; }
        public string TaxYear { get; set; }
        public string PaymentMethod { get; set; }
        public string Source { get; set; }
    }
}