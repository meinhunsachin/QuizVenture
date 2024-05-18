using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

[Route("api/[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private List<Question> _questions;

    public QuizController()
    {
        // Load the JSON data into a list of QuizQuestion objects (You'll need to implement your logic to read the JSON file)
        _questions = LoadQuestionsFromJson();
        // Implement this method to load your JSON data
    }
    private static List<Question> LoadQuestionsFromJson()
    {
        List<Question> quizQuestions = new List<Question>();

        try
        {
            // string jsonFilePath = "../Question.json"; // Replace with your JSON file path
            //string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Question.json");
            //F:\PROJECTS\QuizVentureAPI>
            string jsonFilePath = "F:/PROJECTS/QuizVentureAPI/Question.json";//data load from json file 
           
            if (System.IO.File.Exists(jsonFilePath))
            {
                string jsonString = System.IO.File.ReadAllText(jsonFilePath);
                quizQuestions = JsonSerializer.Deserialize<List<Question>>(jsonString);
            }
            else
            {
              
            }
        }
        catch (Exception ex)
        {
            
            // Handle exceptions according to your application's requirements
        }

        return quizQuestions;
    }
    [HttpGet]
    public ActionResult<List<Question>> Get()
    {
        return _questions;
    }
    [HttpGet("random")]
    public ActionResult<Question> GetRandomQuestion()
    {
        if (_questions.Count > 0)
        {
            // Get a random question
            Random rand = new Random();
            int randomIndex = rand.Next(0, _questions.Count);

            Question randomQuestion = _questions[randomIndex];
            return randomQuestion;
        }
        else
        {
            return NotFound("No questions available");
        }
    }
}

