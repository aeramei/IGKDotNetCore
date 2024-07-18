// See https://aka.ms/new-console-template for more information
using IGK.DotNetTrainingBatch4.ConsoleAppHttpClientExamples;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

//Console App - client
// Asp.net core web api - Server (Backend)

//HttpClient client = new HttpClient();
//var response = await client.GetAsync("https://localhost:7169/api/blog");

//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(jsonStr);
//   List<BlogDTO> lst = JsonConvert.DeserializeObject<List<BlogDTO>>(jsonStr)!;
//  foreach (var blog in lst)
//    {
//       Console.WriteLine(JsonConvert.SerializeObject(blog));
//       Console.WriteLine($"Author => { blog.BlogAuthor}");
//      Console.WriteLine($"Title => {blog.BlogTitle}");
//        Console.WriteLine($"Content => {blog.BlogContent}");
//    }
// }

HttpClientExample httpClientexample = new HttpClientExample();
await httpClientexample.RunAsync();

 Console.ReadLine();
