using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClubRoomDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new();
            p.Run().Wait();
        }

        private async Task Run()
        {
            // -------------------------------------
            // Fetch source code and extract
            // the JSON URL from data-jsb attribute
            // -------------------------------------
            string pageSource;
            using (HttpClient httpClient = new())
            {
                pageSource = await httpClient.GetStringAsync(new Uri("https://www.radioeins.de/programm/sendungen/club_room/"));
            }

            string firstJson = Regex.Match(pageSource, @"<div.+jsb_playerInitialize-audio.*data-jsb='(.+)'>").Groups[1].Value;
            StageOne.Root stageone = JsonSerializer.Deserialize<StageOne.Root>(firstJson);

            // -------------------------------------
            // Using the extracted URL,
            // fetch another JSON payload which contains
            // the final URL to the MP3 file
            // -------------------------------------
            string stageTwoRaw;
            using (HttpClient httpClient = new())
            {
                stageTwoRaw = await httpClient.GetStringAsync(new Uri($"https://www.radioeins.de{stageone.media}"));
            }

            StageTwo.Root stagetwo = JsonSerializer.Deserialize<StageTwo.Root>(stageTwoRaw);

            Console.WriteLine(stagetwo._mediaArray.First()._mediaStreamArray.First()._stream);

            // Todo: write rest of the app
        }
    }
}
