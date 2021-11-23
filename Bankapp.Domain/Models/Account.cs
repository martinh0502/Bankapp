using System;
using System.Collections.Generic;

#nullable disable

namespace Bankapp.Domain.Models
{
    public partial class Account
    {
        public Account()
        {
            Dispositions = new HashSet<Disposition>();
            Loans = new HashSet<Loan>();
            Transactions = new HashSet<Transaction>();
        }

        public int AccountId { get; set; }
        public string Frequency { get; set; }
        public DateTime Created { get; set; }
        public decimal Balance { get; set; }
        public int? AccountTypesId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AccountType AccountTypes { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Disposition> Dispositions { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Loan> Loans { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
