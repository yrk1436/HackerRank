using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Solution
{

    /*
     * Complete the function below.
     */
    static int getNumberOfMovies(string substr)
    {
        /*
         * Endpoint: "https://jsonmock.hackerrank.com/api/movies/search/?Title=substr"
         */

        var url = "https://jsonmock.hackerrank.com/api/movies/search/?Title=" + substr;
        var jsonresult = GetAsync(url);

        return JsonConvert.DeserializeObject<dynamic>(jsonresult).total;

    }

    public static string GetAsync(string uri)
    {
        using (var client = new HttpClient())
        {
            var response = client.GetAsync(uri).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                return responseContent.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }

        return "{\"total\":\"0\"}";
    }

    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        Console.WriteLine(getNumberOfMovies(s));
        
    }
}