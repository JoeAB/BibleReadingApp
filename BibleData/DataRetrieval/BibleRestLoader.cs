using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BibleComonInterface;
using BibleData.DataEntities;
using Newtonsoft.Json.Linq;

namespace BibleData.DataRetrieval
{
    public class BibleRestLoader : IBibleLoader
    {

        private const String BaseURI = "https://ajith-holy-bible.p.rapidapi.com/";

        public IBook GetBook(string bookID)
        {
            throw new NotImplementedException();
        }

        public List<IBook> GetBooks()
        {
            List<String> books = new List<string>();
            List<IBook> returnList = new List<IBook>();
            String result = Task.Run(async () => await DataFetchAsync(BaseURI + "GetBooks")).Result;

            JObject jObject = JObject.Parse(result);
            String oldTestament = jObject["The_Old_Testament"].ToString(); 
            String newTestament = jObject["The_New_Testament"].ToString();

            books.AddRange(Regex.Split(oldTestament, "\\d+\\."));
            books.AddRange(Regex.Split(newTestament, "\\d+\\."));

            foreach(String book in books)
            {
                if(!String.IsNullOrEmpty(book))
                {
                    returnList.Add(new Book(book));
                }
            }
            return returnList;
        }


        public IChapter GetChapter(IBook book, int chapterNumber)
        {
            throw new NotImplementedException();
        }

        public List<IChapter> GetChapters(IBook book)
        {
            throw new NotImplementedException();
        }

        public IPassage GetPassage(IBook book, IChapter chapter, int startVerse, int endVerse)
        {
            throw new NotImplementedException();
        }

        public bool Initialize()
        {
            throw new NotImplementedException();
        }

        private async Task<string> DataFetchAsync(String url)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "x-rapidapi-host", "ajith-holy-bible.p.rapidapi.com" },
                    { "x-rapidapi-key", GetKey() },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        private String GetKey()
        {
            //I'm just storing the key locally, since it's not like this is going to be deployed anywere
            string path = @"C:\Keys\BibleKey.txt";
            string readText = File.ReadAllText(path);
            return readText; 
        }


        //            String result = File.ReadAllText("C:\\Keys\\en_bbe.JSON");
       // var jObject = JArray.Parse(result);
    }
}
