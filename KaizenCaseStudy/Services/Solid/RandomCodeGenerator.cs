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
                var ValidCodeCompany = Random.Next(0,3);
                var CompanyName = "";
                switch (ValidCodeCompany)
                {
                    case 0:
                        CompanyName = "Coca Cola";
                        break;
                    case 1:
                        CompanyName = "Pepsi";
                        break;
                    case 2:
                        CompanyName = "Magnum";
                        break;
                    default:
                        break;
                }
                var Code = GenerateSingleCode(8);
                if(IsCodeValid(CodeList,Code))
                    CodeList.Add(Code, CompanyName);
            }

            return CodeList;
        }

        public string GenerateSingleCode(int length)
        {
            Random Random = new Random();
            char[] Result = new char[length];

            for (int i = 0; i < length; i++)
            {
                int index = Random.Next(CodeCharacters.Length);
                Result[i] = CodeCharacters[index];
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
