using KaizenCaseStudy.Models;
using KaizenCaseStudy.Services.Abstract;
using Newtonsoft.Json;
using static KaizenCaseStudy.Models.Bill;

namespace KaizenCaseStudy.Services
{
    public class BillParser : IBillParser
    {
        public string ParseSelectedBill()
        {
            string jsonFilePath = "Services\\Attachments\\response.json";

            // JSON dosyasını okuyun
            string jsonString = File.ReadAllText(jsonFilePath);

            // JSON verisini istediğiniz bir modele dönüştürün
            var model = JsonConvert.DeserializeObject<List<Bill>>(jsonString);
            var billStr = "";
            var treshold = 15;
           for(int i = 1; i < model.Count; i++)
            {
                if (!string.IsNullOrEmpty(model[i - 1].locale))
                {
                    continue;
                }

                if(model[i].boundingPoly.vertices[0].y - model[i-1].boundingPoly.vertices[0].y < treshold) //iki string yan yana
                {
                    billStr += model[i - 1].description + " ";
                } else
                {
                    billStr += model[i - 1].description + "\n";
                }

                if(i == model.Count -1)
                {
                    billStr += model[i].description + " ";
                }
            }

            return billStr;
        }
    }
}
