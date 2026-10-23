using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Exceptions;
using SDK.Models;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Questions : Requests
    {
        [TestCategory("Question")]
        [TestMethod]
        public async Task GetQuestionsByWorkRole_ErrorHandling_ShouldThrowsException()
        {
            const int WorkRoleId = 1;
            var bodyContent = new ProblemDetails { Title = "Questions error", Detail = "Failed." };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "questions/work-role/" + WorkRoleId).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(
                async () => await devkitConnector.GetQuestionsByWorkRole(WorkRoleId));
        }

        [TestCategory("Question")]
        [TestMethod]
        public async Task GetQuestionsByWorkRole_ShouldReturn200()
        {
            const int WorkRoleId = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "questions/work-role/" + WorkRoleId).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new QuestionWrapperContract { WorkRoleId = WorkRoleId }));

            var response = await devkitConnector.GetQuestionsByWorkRole(WorkRoleId);
            Assert.IsInstanceOfType(response, typeof(QuestionWrapperContract));
        }

        [TestCategory("Question")]
        [TestMethod]
        public async Task SubmitAnswers_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "answers/submit/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.SubmitAnswers(new AnswerWrapperContract { Role = 1 });
        }
    }
}
