using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhotoAlbumLT
{
    public class PhotoAlbum
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.Write("Type Photo Album Number: ");
                int x;
                // Check if user input is Integer?
                while (!int.TryParse(Console.ReadLine(), out x))
                    Console.WriteLine("The value must be of integer type, try again: ");

                Console.WriteLine("Photo-Album " + x);
                Task t =Task.Run(() => ApiCall(x));
                t.Wait();
                
            } while (Console.ReadLine() != "N");
            
                   
        }
        public static async void ApiCall(int number)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/photos?albumId=" + number);

                    response.EnsureSuccessStatusCode();

                    using (HttpContent content = response.Content)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        var articles = JsonConvert.DeserializeObject<List<Album>>(responseBody);

                        //CHECK if List is Empty, if List is empty, Album Doesn't Exist.
                        if (!articles.Any())
                        {
                            Console.WriteLine("Album number doesn't exist.");
                            Console.WriteLine("Press anything to Continue or N to Exit: ");
                        }
                        else {
                            foreach (var alb in articles)
                            {
                                Console.WriteLine("[{0}]\t{1}\n", alb.Id, alb.Title);

                            }
                            Console.WriteLine("Press anything to Continue or N to Exit: ");
                        }
                    }

                }
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
