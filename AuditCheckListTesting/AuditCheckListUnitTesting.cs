using AuditCheckList.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;

namespace AuditCheckListTesting
{
    public class AuditCheckList_Controller_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAuditCheckListQuestions_WhenInvalidInputIsPassed_ReturnsBadRequest()
        {
            //Arrange
            string AuditType = "InvalidInput";

            //Act
            AuditCheckListController Controller = new AuditCheckListController();
            var ControllerOutput = Controller.GetAuditCheckListQuestions(AuditType);
            var result = ControllerOutput.Result as BadRequestObjectResult;
            //Assert
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Invalid Input(Please Enter valid AuditTpe)", result.Value);
        }

   

        [Test]
        public void GetAuditCheckListQuestions_WhenAuditTypeIsInternal_ReturnsListOfInternalTypeAuditQuestions()
        {
            //Arrange
            string AuditType = "InteRnal";
            List<string> InternalQuestion = new List<string>();
            InternalQuestion.Add("Have all Change requests followed SDLC before PROD move? ");
            InternalQuestion.Add("Have all Change requests been approved by the application owner?");
            InternalQuestion.Add("Are all artifacts like CR document, Unit test cases available?");
            InternalQuestion.Add("Is the SIT and UAT sign-off available?");
            InternalQuestion.Add("Is data deletion from the system done with application owner approval?");
           
            //Act
            AuditCheckListController Controller = new AuditCheckListController();
            var ControllerListOfQuestion = Controller.GetAuditCheckListQuestions(AuditType);
            var Result = ControllerListOfQuestion.Result as OkObjectResult;

            //Assert
            Assert.AreEqual(200, Result.StatusCode);
            Assert.AreEqual(InternalQuestion, Result.Value);

        }

        [Test]
        public void GetAuditCheckListQuestions_WhenAuditTypeIsSOX_ReturnsListOfSOXTypeAuditQuestions()
        {
            //Arrange
            string AuditType = "SOX";
            List<string> SOXQuestion = new List<string>();
            SOXQuestion.Add("Have all Change requests followed SDLC before PROD move?");
            SOXQuestion.Add("Have all Change requests been approved by the application owner?");
            SOXQuestion.Add("For a major change, was there a database backup taken before and after PROD move?");
            SOXQuestion.Add("Has the application owner approval obtained while adding a user to the system?");
            SOXQuestion.Add("Is data deletion from the system done with application owner approval?");
            
            //Act
            AuditCheckListController Controller = new AuditCheckListController();
            var ControllerListOfQuestion = Controller.GetAuditCheckListQuestions(AuditType);
            var Result = ControllerListOfQuestion.Result as OkObjectResult;

            //Assert
            Assert.AreEqual(200,Result.StatusCode);
            Assert.AreEqual(SOXQuestion, Result.Value);

        }
   }
}