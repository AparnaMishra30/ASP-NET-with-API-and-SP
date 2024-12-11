using System;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Training_webApp.Models
{
    public class studentController : ApiController
    {
        public static DataSet CallApiGetds(string URL)
        {
            APIResponse _Res = new APIResponse();
            try
            {
                HttpClient HClient = new HttpClient
                {
                    BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"].ToString())
                };
                HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HClient.Timeout = TimeSpan.FromMinutes(10);
                var response = HClient.GetAsync(URL).Result;
                var a = response.Content.ReadAsStringAsync().Result.ToString();
                DataSet ds = new DataSet();
                _Res = JsonConvert.DeserializeObject<APIResponse>(a);
                // ds = JsonConvert.DeserializeObject<DataSet>(_Res.data.ToString());
                if (_Res.data != null)
                {
                    ds = JsonConvert.DeserializeObject<DataSet>(_Res.data.ToString());
                }
                return ds;
            }
            catch (Exception)
            {
                DataSet ds;
                return ds = null;
            }
        }

        internal static DataSet CallApiPostds(PL_student plobj, string URL)
        {
            APIResponse _Res = new APIResponse();
            try
            {
                HttpClient HClient = new HttpClient
                {
                    BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"].ToString())
                };
                HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HClient.Timeout = TimeSpan.FromMinutes(60);
                var json = JsonConvert.SerializeObject(plobj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = HClient.PostAsync(URL, content).Result;
                var a = response.Content.ReadAsStringAsync().Result.ToString();
                DataSet ds = new DataSet();
                _Res = JsonConvert.DeserializeObject<APIResponse>(a);
                if (_Res.data != null)
                {
                    ds = JsonConvert.DeserializeObject<DataSet>(_Res.data.ToString());
                }
                // ds = JsonConvert.DeserializeObject<DataSet>(a);
                return ds;
            }
            catch (Exception)
            {
                DataSet ds;
                return ds = null;
            }
        }

       
    }
}
