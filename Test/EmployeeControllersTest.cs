using LMS.Controllers;
using LMS.Controllers.AdminControllers;
using LMS.Models;
using LMS.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class EmployeeControllersTest
    {
        private Mock<IItemDataManagementService> AdminServiceObj;
        
        private AdminItemDataManagementController adminController;
        private ItemMaster itemsMaster = new ItemMaster { ItemId=new Guid("I0001"), ItemCategory="Furniture", IssueStatus="Y", ItemDescription="Table", ItemMake="Wood", ItemValuation=5000 };

        [SetUp]
        public void Setup()
        {
            AdminServiceObj = new Mock<IItemDataManagementService>();

            adminController = new AdminItemDataManagementController(AdminServiceObj.Object);
        }

    
        [Test]
        public void GetItems_Test()
        {
            AdminServiceObj.Setup(_ => _.GetItemMastersAsync()).Returns(itemsMaster);
            Task result = adminController.GetItemMasters();
            Assert.That(result, Is.InstanceOf<Task<ActionResult>>());
            Task<ActionResult> taskResult = (Task<ActionResult>)result;
            System.Diagnostics.Debug.WriteLine(taskResult.Result);
            //Assert.That(taskResult.Result, Is.AssignableTo<ItemMaster>());
        }
    }
}
