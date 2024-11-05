using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public static class WebScraper
    {
        public static async Task<string> YankDatRandWord()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resp = await client.GetAsync("https://random-word-api.herokuapp.com/word");
                if (resp.IsSuccessStatusCode)
                {
                    string result = await resp.Content.ReadAsStringAsync();
                    return result.Substring(2, result.Length - 4);
                }
            }
            return String.Empty;
        }
    }
}
