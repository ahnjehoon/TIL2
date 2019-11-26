using Newtonsoft.Json;
using pms_develop.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using UtilLibrary;

namespace pms_develop.View.common
{
    /// <summary>
    /// commonPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class commonPage : Page
    {
        static HttpClient client;
        public commonPage()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/");
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMilliseconds(3000);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DBUtil dbUtil = new DBUtil();
            if (dbUtil.connectTest())
            {
                Console.WriteLine("리얼성공");
            }
            else
            {
                Console.WriteLine("실패");
            }
        }

        private async void rest_api_test(object sender, RoutedEventArgs e)
        {
            try
            {
                //HttpResponseMessage response = new HttpResponseMessage();
                // response = client.GetAsync("hihi").Result;
                var response = await client.GetAsync("hihi");
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                List<LANGUAGE_INFO> obj = JsonConvert.DeserializeObject<List<LANGUAGE_INFO>>(result);

                System.Diagnostics.Debug.WriteLine(result);
            }
            catch
            {

            }
        }

        public static T Desrialize<T>(String json)
        {
            Newtonsoft.Json.JsonSerializer s = new JsonSerializer();
            return s.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }
    }
}
