using AcmePortal.Business.Implementations;
using AcmePortal.Business.Interfaces;
using AcmePortal.Business.Models;
using AcmePortal.Controllers;
using AcmePortal.Repository.Implementations;
using AcmePortal.Repository.Interfaces;
using AcmePortal.Repository.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AcmePortal.Tests
{
    public class TestAcmeActivityController
    {
        private readonly AcmeActivityController acmeActivityController;
        private readonly IAcmeActivityManager acmeActivityManager;
        //this should be retrieved from app settings 
        private const string dbconnections = "Server=edpathway.database.windows.net;Database=edpathway;UID=acmeadmin; Pwd=acmetest123!;"; 
        public TestAcmeActivityController()
        {
           
            var services = new ServiceCollection();
            services.AddTransient<IAcmeActivityManager, AcmeActivityManager>();
            services.AddTransient<IAcmeActivityRepo, AcmeActivityRepo>();

            services.AddDbContext<AcmeContext>(options => options.UseSqlServer(dbconnections));

            var serviceProvider = services.BuildServiceProvider();

            acmeActivityManager = serviceProvider.GetService<IAcmeActivityManager>();
            acmeActivityController = new AcmeActivityController(acmeActivityManager);
        }
        
        [Fact]
        public void GetAllRegisteredRecords()
        {
            List<VAcmeActivity> result = (acmeActivityController.GetAll() as OkObjectResult).Value as List<VAcmeActivity>;

            List<VAcmeActivity> testRecords = GetTestRecords();

            Assert.Equal(testRecords.Count, result.Count);
            Assert.Equal(testRecords.FirstOrDefault().Firstname, result.FirstOrDefault().Firstname);
            Assert.Equal(testRecords.FirstOrDefault().Comments, result.FirstOrDefault().Comments);
        }

        [Fact]
        public async Task VerifyNewRecord()
        {
            VAcmeActivity testRecord = GenerateTestRecord();

            await acmeActivityController.AddNewRecord(testRecord);

            VAcmeActivity actualRecord = GetNewlyInsertedRecord();

            Assert.Equal(testRecord.Firstname, actualRecord.Firstname);
            Assert.Equal(testRecord.Activity, actualRecord.Activity);
            Assert.Equal(testRecord.Comments, actualRecord.Comments);
        }

        private VAcmeActivity GenerateTestRecord()
        {
            return new VAcmeActivity() {Firstname = "Zixu", Lastname = "Gu", Email = "fakeemail@abc.com", Activity = "Movie night", Comments = "Looking forward to movie night!" };
        }
        private List<VAcmeActivity> GetTestRecords()
        {
            List<VAcmeActivity> testRecords = new List<VAcmeActivity>();
            using (AcmeContext db = new AcmeContext(new DbContextOptionsBuilder<AcmeContext>().UseSqlServer(dbconnections).Options))
            {
                foreach(AcmeActivity a in db.AcmeActivity)
                {
                    testRecords.Add(new VAcmeActivity { Id = a.Id, Firstname = a.Firstname, Lastname = a.Lastname, Activity = a.Activity, Comments = a.Comments });
                }
             
            }
            return testRecords;
        }

        private VAcmeActivity GetNewlyInsertedRecord()
        {
            VAcmeActivity testRecord = null;
            using (AcmeContext db = new AcmeContext(new DbContextOptionsBuilder<AcmeContext>().UseSqlServer(dbconnections).Options))
            {
                AcmeActivity latestRecord = db.AcmeActivity.LastOrDefault();
                testRecord = new VAcmeActivity { Id = latestRecord.Id, Firstname = latestRecord.Firstname, Lastname = latestRecord.Lastname, Activity = latestRecord.Activity, Comments = latestRecord.Comments };
                

            }
            return testRecord;
        }


    }
}
