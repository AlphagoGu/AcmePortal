using AcmePortal.Business.Models;
using AcmePortal.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmePortal.Business.Interfaces
{
    public interface IAcmeActivityManager
    {
        List<VAcmeActivity> GetAllRecords();
        Task<int> AddNewRecord(VAcmeActivity newrecord);
    }
}
