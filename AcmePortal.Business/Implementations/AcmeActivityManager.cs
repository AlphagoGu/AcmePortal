using AcmePortal.Business.Interfaces;
using AcmePortal.Business.Models;
using AcmePortal.Repository.Interfaces;
using AcmePortal.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmePortal.Business.Implementations
{
    public class AcmeActivityManager : IAcmeActivityManager
    {
        private IAcmeActivityRepo _acmeActivityRepo;

        public AcmeActivityManager(IAcmeActivityRepo acmeActivityRepo)
        {
            _acmeActivityRepo = acmeActivityRepo;
        }

        public List<VAcmeActivity> GetAllRecords()
        {
            IQueryable<AcmeActivity> dbrecords = _acmeActivityRepo.FindAll();
            if(dbrecords != null && dbrecords.Count() > 0)
            {
                List<VAcmeActivity> allrecords = new List<VAcmeActivity>();
                foreach (AcmeActivity aa in dbrecords)
                {
                    allrecords.Add(new VAcmeActivity()
                    {
                        Id = aa.Id, Firstname = aa.Firstname,
                        Lastname = aa.Lastname,
                        Activity = aa.Activity,
                        Email = aa.Email,
                        Comments = aa.Comments
                    });
                }
                return allrecords.OrderBy(c=>c.Activity).ToList();
            }
            else
            {
                return null;
            }
          
        }

        public async Task<int> AddNewRecord(VAcmeActivity newrecord)
        {
            AcmeActivity dbrecord = new AcmeActivity()
            {
                Firstname = newrecord.Firstname,
                Lastname = newrecord.Lastname,
                Email = newrecord.Email,
                Activity = newrecord.Activity,
                Comments = newrecord.Comments
            };

            try
            {
                DbTransactionResult result = await _acmeActivityRepo.CreateAsync(dbrecord);
                return result.HasError == false ? 0: -1;
            }
            catch(Exception e)
            {
                string msg = e.Message;
                return -1;
            }
        }
    }
}
