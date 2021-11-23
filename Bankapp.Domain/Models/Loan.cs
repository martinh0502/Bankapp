using System;
using System.Collections.Generic;

#nullable disable

namespace Bankapp.Domain.Models
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; }
        public decimal Payments { get; set; }
        public string Status { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Account Account { get; set; }
    }
}
