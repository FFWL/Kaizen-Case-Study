namespace KaizenCaseStudy.Services.Abstract
{
    public interface IRandomCodeGenerator
    {
        Dictionary<string, string> RandomCodeGenerate(int count);
    }
}
