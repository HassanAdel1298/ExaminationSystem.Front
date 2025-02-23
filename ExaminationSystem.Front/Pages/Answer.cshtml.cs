using ExaminationSystem.Front.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ExaminationSystem.Front.Pages
{
    public class AnswerModel : PageModel
    {
        public QuizDetailsDto QuizDetails { get; set; }

        [BindProperty(SupportsGet = true)]
        public int QuizID { get; set; }
        public async void OnGet()
        {
            String conn = "https://localhost:44302/api/ShowQuizDetails?quizId=" + QuizID;
            ResultDTO resultDTO = new ResultDTO();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(conn))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    resultDTO = JsonConvert.DeserializeObject<ResultDTO>(apiResponse);
                    if (resultDTO != null && resultDTO.IsSuccess)
                    {
                        QuizDetails = resultDTO.Data;
                    }

                }
            }
        }

        public async Task<IActionResult> OnPost()
        {
            String conn = "https://localhost:44302/api/AnswerQuestions";
            ResultDTO resultDTO = new ResultDTO();

            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();

                using (var response = await httpClient.PostAsync(conn, httpRequestMessage.Content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    resultDTO = JsonConvert.DeserializeObject<ResultDTO>(apiResponse);
                    if (resultDTO != null && resultDTO.IsSuccess)
                    {
                        return RedirectToPage("/Index");
                    }
                    return Page();
                }
            }
        }
    }
}
