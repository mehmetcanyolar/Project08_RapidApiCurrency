using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project08_RapidApiCurrency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            #region Dollar

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=USD&to=TRY&amount=1"),
                Headers =
         {
             { "x-rapidapi-key", "8e2153b60cmshad87d4c02fb4d8fp1ddcabjsned53ab11d2ad" },
             { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
         },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
               
                
                //Console.WriteLine(body);

                var jsonObject= JObject.Parse(body);
                var value = jsonObject["result"].ToString();

                lblDollar.Text = value;


            }

            #endregion


            #region Euro

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=EUR&to=TRY&amount=1"),
                Headers =
         {
             { "x-rapidapi-key", "8e2153b60cmshad87d4c02fb4d8fp1ddcabjsned53ab11d2ad" },
             { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
         },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();



                var jsonObject2 = JObject.Parse(body2);
                var value2 = jsonObject2["result"].ToString();

                lblEuro.Text = value2;


            }
            #endregion

            #region Sterling

            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=GBP&to=TRY&amount=1"),
                Headers =
         {
             { "x-rapidapi-key", "8e2153b60cmshad87d4c02fb4d8fp1ddcabjsned53ab11d2ad" },
             { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
         },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();


               

                var jsonObject3 = JObject.Parse(body3);
                var value3 = jsonObject3["result"].ToString();

                lblSterling.Text = value3;

                #endregion
            }
                txtTotalPrice.Enabled = false; //dısarıdan müdahaleye kapatıldı
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            decimal unitPrice = decimal.Parse(txtUnitPrice.Text);
            if (rdbDollar.Checked)
            {
                decimal totalPrice = unitPrice * decimal.Parse(lblDollar.Text);
                
                txtTotalPrice.Text = totalPrice.ToString() +" $";
            }

            if (rdbEuro.Checked)
            {
                decimal totalPrice = unitPrice * decimal.Parse(lblEuro.Text);

                txtTotalPrice.Text = totalPrice.ToString() +" €";
            }

            if (rdbSterling.Checked)
            {
                decimal totalPrice = unitPrice * decimal.Parse(lblSterling.Text);

                txtTotalPrice.Text = totalPrice.ToString()+ " GBP";

            }
        }
    }
}
