using AcmePortal.Repository.Interfaces;
using AcmePortal.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmePortal.Repository.Implementations
{
    public class AcmeActivityRepo : RepositoryBase<AcmeActivity>, IAcmeActivityRepo
    {
        public AcmeActivityRepo(AcmeContext acmeContext)
           : base(acmeContext)
        {
        }
    }
}
