using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace ProductAPP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetProduct();
        }

        public async void GetProduct()
        {
            try {
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromHours(200);
                Console.WriteLine("hello");
                //string response = "[{ ProductId: 1, ProductName: \"Pen\", Price: \"5\"}]";
                //JObject jsnobject = new JObject(response);
                var my_jsondata = new {
                    ProductId=@"1",
                    ProductName="Pen",
                    Price="10"
                };

                //Tranform it to Json object
                string json_data = JsonConvert.SerializeObject(my_jsondata);

                //Print the Json object
                Console.WriteLine(json_data);

                //Parse the json object
                JObject json_object = JObject.Parse(json_data);
                //var response = await client.GetStringAsync("http://192.168.0.101:6167/api/Product/GetAllProducts");
                Console.WriteLine("Hello2");
               // Console.WriteLine(response);
                //192.168.0.101
                //localhost:44351
                var products = JsonConvert.DeserializeObject<List<Products>>(json_data);
                ProductListView.ItemsSource = products;
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            
        }
    } 
}
