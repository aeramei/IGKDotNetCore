// See https://aka.ms/new-console-template for more information
using System.Text.Json.Serialization;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

String jsonStr = await File.ReadAllTextAsync("data.json");
var model = JsonConvert.DeserializeObject<MainDTO>(jsonStr);

// Console.WriteLine(jsonStr);

//JSON to C#?? need package 
// C# to JSON

foreach (var queation in model.questions)
{
    Console.WriteLine(queation.questionName);
}

Console.ReadLine();

static string ToNumber(string num)
{
    num = num.Replace("၃", "3");
    num = num.Replace("၃", "3");
    num = num.Replace("၃", "3");
    num = num.Replace("၃", "3");
    return num;
}

public class MainDTO
{
    public Question[] questions { get; set; }
    public Answer[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Question
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answer
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}

