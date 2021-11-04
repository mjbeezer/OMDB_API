using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OMDBapi.Models
{
    public class MovieDAL
    {
        public MovieModel GetData(string title)
        {
            string key = "a12ec17f";
            string url = $"http://www.omdbapi.com/?apikey={key}&t={title}";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string JSON = reader.ReadToEnd();

            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);

            return result;
        }
    }
}
