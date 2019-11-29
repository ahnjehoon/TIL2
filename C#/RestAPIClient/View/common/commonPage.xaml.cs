using Newtonsoft.Json;
using RestAPIClient.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace pms_develop.View.common
{
    /// <summary>
    /// commonPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class commonPage : Page
    {
        int count = 0;
        static HttpClient client;
        public commonPage()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/");
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMilliseconds(3000);
        }

        private async void rest_api_test(object sender, RoutedEventArgs e)
        {
            try
            {
                //HttpResponseMessage response = new HttpResponseMessage();
                // response = client.GetAsync("hihi").Result;
                var response = await client.GetAsync("/api/LanguageInfo");
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                List<LanguageInfo> obj = JsonConvert.DeserializeObject<List<LanguageInfo>>(result);

                System.Diagnostics.Debug.WriteLine(result);
                this.textBox.Text = result;

                //this.textBox1.Text = obj[0];
                this.textBox1.Text = null;
                foreach (var s in obj)
                {
                    this.textBox1.Text += s.LanguageCode + "\n";
                }
            }
            catch
            {

            }
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var response = string.Empty;
            count++;
            String payload = JsonConvert.SerializeObject(new
            {
                LANGUAGECODE = count.ToString()
                ,
                LANGUAGEVALUE1 = count.ToString() + "한글1"
                ,
                LANGUAGEVALUE2 = count.ToString() + "한글2"
                ,
                LANGuAGEVALUE3 = count.ToString() + "한글3"
                ,
                comment = "코멘트입니다"
            });
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            //var result = await client.PostAsync("/api/LanguageInfo", content);
            //System.Diagnostics.Debug.WriteLine(result);
            using (var client = new HttpClient())
            {
                Uri uri = new Uri("http://localhost/api/LanguageInfo");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post
                    ,
                    RequestUri = uri
                    ,
                    Content = content
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
            }
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            await client.DeleteAsync("/api/LanguageInfo");
        }
    }
}
