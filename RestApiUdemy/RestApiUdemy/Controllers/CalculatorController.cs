using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApiUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //GET API/VALUE/5
        [HttpGet("{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = convertToDecimal(firstNumber) + convertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        private decimal convertToDecimal(string number)
        {
            decimal decimalvalue;

            if (decimal.TryParse(number, out decimalvalue))
            {
                return decimalvalue;
            }

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }
    }
}