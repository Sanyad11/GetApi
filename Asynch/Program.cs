using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;


namespace GetApi
{
    class Program
{
        static async void GetAsync()
        {
            Task[] tasks = new Task[2]
               {
                    new Task(() => Get("http://get-simple.info/api/")),
                    new Task(() => Get("http://get-simple.info/wiki/ru"))
               };
            foreach (var t in tasks)
                t.Start();
            Task.WaitAll(tasks);
        }
        static async void Get(string str)
        {
            var client = new HttpClient();
            var response =  client.GetAsync(str).Result;
            var responseContent = response.Content;
            string responseS = responseContent.ReadAsStringAsync().Result;
           //Console.WriteLine(responseS);
        }

        static void Main()
        {
            Stopwatch sw;
            sw = Stopwatch.StartNew();
            Get("http://get-simple.info/wiki/ru");
            Get("http://get-simple.info/api/");
            Console.WriteLine("time Sync = " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw = Stopwatch.StartNew();
            GetAsync();
            Console.WriteLine("time Async = " + sw.ElapsedMilliseconds);
            sw.Stop();


            Console.ReadLine();
        }

}
}

