using System;
using WidgetDivisas.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace WidgetDivisas.DataAccess
{
    public class DivisasAccess
    {
        public async Task<DivisasData> GetDivisasAsync()
        {
            string id = "0a9c6f3b3010452b90bd68a333765410";
            string url = string.Format("https://openexchangerates.org/api/latest.json?app_id={0}", id);
            DivisasData results = new DivisasData();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        var tem = res.Content.ReadAsStringAsync().Result;
                        if (tem.Length > 0)
                        {
                            JsonConvert.PopulateObject(tem, results);
                        }
                    }
                }
            }
            catch (Exception e) { }
            return results;
        }
    }
}