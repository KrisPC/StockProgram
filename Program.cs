//Author:Kris, Noah, David
// date 03/11/2020
// objective: proof of concept
//API used alphavatage
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
// will be named later
namespace StockProgram
{
  internal class Stock
  {
    public Double Price { get; set; }
    public string Name { get; set; }
  }
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }
    public static async Task<Stock> RunASync(string input)
    {
      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri("https://www.alphavantage.co/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = await client.GetAsync($"query?function=GLOBAL_QUOTE&symbol={input}&apikey=1IB76KJ1VBK8IQXF");
        try
        {
          if (response.IsSuccessStatusCode)
          {
            JObject jsonResponse = await response.Content.ReadAsAsync<JObject>();
            Stock currStock = new Stock
            {
              Price = Double.Parse(jsonResponse["Global Quote"]["05. price"].ToString()),
              Name = jsonResponse["Global Quote"]["01. symbol"].ToString()
            };
            return currStock;
          }
          else
          {
            Stock failedStock = new Stock();
//will give more meaningful error in the future
            failedStock.Name = "error";
            failedStock.Price = 0;
            return failedStock;
          }
        }
        catch
        {
          Stock failedStock = new Stock();
//will give more meaningful error in the future
          failedStock.Name = "error";
          failedStock.Price = 0;
          return failedStock;
        }
      }
    }
  }
}
