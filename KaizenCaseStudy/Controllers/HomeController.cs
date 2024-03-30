using KaizenCaseStudy.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KaizenCaseStudy.Controllers
{
    [ApiController]
    public class KaizenController : ControllerBase
    {

        readonly private IRandomCodeGenerator _randomCodeGenerator;
        readonly private IBillParser _billParser;

        public KaizenController(IRandomCodeGenerator randomCodeGenerator,IBillParser billParser)
        {
            _randomCodeGenerator = randomCodeGenerator;
            _billParser = billParser;

        }

        [HttpPost("PostCodeGenerate")]
        public async Task<IActionResult> PostCodeGenerate(int count)
        {
           var codes = _randomCodeGenerator.RandomCodeGenerate(count);
            return Ok(codes);
        }

        [HttpPost("PostBillParse")]
        public async Task<IActionResult> PostBillParse()
        {
            var codes = _billParser.ParseSelectedBill();
            return Ok(codes);
        }
    }
}
