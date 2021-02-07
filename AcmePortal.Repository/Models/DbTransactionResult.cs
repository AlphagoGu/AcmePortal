using System;
using System.Collections.Generic;
using System.Text;

namespace AcmePortal.Repository.Models
{
    public class DbTransactionResult
    {
        public enum RcrdState { rcrdUnknown = 0, rcrdAdded = 1, rcrdFound = 2, rcrdNotFound = 3 };
        private bool hasError;
        private string error;

        public DbTransactionResult()
        {
            hasError = false;
            error = null;
            state = RcrdState.rcrdUnknown;
        }

        public DbTransactionResult(string error)
        {
            this.Error = error;
        }

        public bool HasError
        {
            get { return hasError; }
            set { hasError = value; }
        }

        public string Error
        {
            get { return error; }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    HasError = true;
                    error = value;
                }
            }
        }

        public RcrdState state;
        public object Entity { get; set; }
    }
}
