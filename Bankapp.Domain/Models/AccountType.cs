using System;
using System.Collections.Generic;

#nullable disable

namespace Bankapp.Domain.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        public int AccountTypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
