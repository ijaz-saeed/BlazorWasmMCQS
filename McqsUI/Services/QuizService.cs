using McqsUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace McqsUI.Services
{
    public class QuizService
    {
        private readonly HttpClient http;

        public QuizService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<QuizDTO> GetQuizAsync(long Id)
        {
            var data = await http.GetFromJsonAsync<QuizDTO[]>("sample-data/quiz-data.json");

            return data.Where(q => q.Id == Id).FirstOrDefault();
        }

        public async Task<QuizResultDTO> AnalyzeQuizAsync(QuizDTO quiz)
        {
            var data = await http.PostAsJsonAsync<QuizDTO>("Analyze.json", quiz);

            QuizResultDTO returnValue = await data.Content.ReadFromJsonAsync<QuizResultDTO>();

            return returnValue;
        }
    }
}
