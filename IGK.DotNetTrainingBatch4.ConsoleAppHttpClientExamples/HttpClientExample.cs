using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IGK.DotNetTrainingBatch4.ConsoleAppHttpClientExamples
{
    internal class HttpClientExample
    {
       private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7169") };
        private readonly string _blogEndpoint = "api / blog";
        public async Task RunAsync()
        {
            // await ReadAsync();
            // await EditAsync(1);
            //await EditAsync(3006);

            //await CreateAsync("author2", "title", "content3");
            await UpdateAsync(3006, "author2", "title 5", "content3");
            await EditAsync(3006);
        }

        private async Task ReadAsync()
        {
            
            var response = await _client.GetAsync(_blogEndpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(jsonStr);
                List<BlogDTO> lst = JsonConvert.DeserializeObject<List<BlogDTO>>(jsonStr)!;
                foreach (var item in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Author => {item.BlogAuthor}");
                    Console.WriteLine($"Title => {item.BlogTitle}");
                    Console.WriteLine($"Content => {item.BlogContent}");
                }
            }
        }

        private async Task EditAsync(int id)
        {
            var response = await _client.GetAsync($"{_blogEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(jsonStr);
                var item = JsonConvert.DeserializeObject<BlogDTO>(jsonStr)!;
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Author => {item.BlogAuthor}");
                    Console.WriteLine($"Title => {item.BlogTitle}");
                    Console.WriteLine($"Content => {item.BlogContent}");        
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task CreatAsync (string author, string title, string content)
        {
            BlogDTO blogdto = new BlogDTO()
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content
            }; 

            //To JSON
            string blogJson = JsonConvert.SerializeObject(blogdto);

            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
           var response =  await _client.PostAsync(_blogEndpoint, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }

        }

        private async Task UpdateAsync(int id, string author, string title, string content)
        {
            BlogDTO blogdto = new BlogDTO()
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content
            };

            //To JSON
            string blogJson = JsonConvert.SerializeObject(blogdto);

            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PutAsync($"{_blogEndpoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }

        }

        private async Task DeletAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_blogEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
        }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }
}
