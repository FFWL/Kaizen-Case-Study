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

            string jsonString = File.ReadAllText(jsonFilePath);

            var model = JsonConvert.DeserializeObject<List<Bill>>(jsonString);
            var billStr = "";
            var treshold = 15;

            SortBillElements(model,0);
           for (int i = 1; i < model.Count; i++)
            {
                if (!string.IsNullOrEmpty(model[i - 1].locale))
                {
                    continue;
                }

                if(model[i].boundingPoly.vertices[0].y - model[i-1].boundingPoly.vertices[1].y < treshold)
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

        public List<Bill> SortBillElements(List<Bill> bills, int corner)
        {
            bills.Sort((a, b) =>
            {
                int diff = b.boundingPoly.vertices[corner].y - a.boundingPoly.vertices[corner].y;
                int result = a.boundingPoly.vertices[corner].y.CompareTo(b.boundingPoly.vertices[corner].y);
                if (result == 0) // if y coordinates are the same check for x
                {
                    result = a.boundingPoly.vertices[corner].x.CompareTo(b.boundingPoly.vertices[corner].x);
                 } else if (diff == 1 || diff == -1) // bu koşul, OCR içerisinde oluşturulan, aynı satırda görünen fakat aralarında 1 piksel fark olan dikdörtgenleri elemek için konulmuştur
                {
                    result = a.boundingPoly.vertices[corner].x.CompareTo(b.boundingPoly.vertices[corner].x);

                }
                return result;
            });
            return bills;

        }
    }
}
