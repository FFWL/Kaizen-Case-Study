using KaizenCaseStudy.Services.Abstract;

namespace KaizenCaseStudy.Services
{
    public class RandomCodeGenerator : IRandomCodeGenerator
    {
        static string CodeCharacters = "ACDEFGHKLMNPRTXYZ234579";
        public Dictionary<string, string> RandomCodeGenerate(int count)
        {
            var Random = new Random();
            Dictionary<string, string> CodeList = new Dictionary<string, string>();
            for (int i = 0; i < count; i++)
            {
                var ValidCodeProduct = Random.Next(0,3);
                var ProductName = "";
                switch (ValidCodeProduct)
                {
                    case 0:
                        ProductName = "Coca Cola";
                        break;
                    case 1:
                        ProductName = "Pepsi";
                        break;
                    case 2:
                        ProductName = "Magnum";
                        break;
                    default:
                        break;
                }
                var Code = GenerateSingleCode(8);
                if(IsCodeValid(CodeList,Code))
                    CodeList.Add(Code, ProductName);
            }

            return CodeList;
        }

        public string GenerateSingleCode(int length)
        {
            Random Random = new Random();
            char[] Result = new char[length];
            //random * random mod length

            for (int i = 0; i < length; i++)
            {
                int index = Random.Next(CodeCharacters.Length);
                // bu işlem, belirli bir örüntü içerisinde kodların oluşturulması için
                //eklenmiştir. Rastgele oluşturulan sayının kübü alınıp karakter dizisi uzunluğuna göre modu ile yeni karakterin belirlenmesi şeklindedir.
                var singleChar = Convert.ToInt32(Math.Pow(index + 1,3)) % CodeCharacters.Length; 
                Result[i] = CodeCharacters[singleChar];
            }

            return new string(Result);
        }

        public bool IsCodeValid(Dictionary<string, string> codeList, string code)
        {
            if (codeList.ContainsKey(code))
                return false;
            return true;
        }
    }
}
