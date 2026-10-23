using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        public async Task<QuestionWrapperContract> GetQuestionsByWorkRole(int workRoleId)
        {
            return await GetRequest<QuestionWrapperContract>(Address.UrlCombine(Address.QuestionsWorkRole, Convert.ToString(workRoleId)));
        }

        public async Task SubmitAnswers(AnswerWrapperContract answers)
        {
            await PostRequest(Address.AnswersSubmit, answers);
        }
    }
}
