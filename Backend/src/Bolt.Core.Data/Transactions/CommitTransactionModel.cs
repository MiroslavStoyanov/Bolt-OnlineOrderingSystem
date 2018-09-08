using System;

namespace Bolt.Core.Data.Transactions
{
    public class CommitTransactionModel
    {
        public bool IsSuccessful => this.CommitException == null;

        public Exception CommitException { get; set; }
    }
}