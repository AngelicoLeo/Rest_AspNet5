using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestAspNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
      
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(!string.IsNullOrEmpty(firstNumber) && !string.IsNullOrEmpty(secondNumber))
            {
                if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sum = Operations("sum", new List<string> { firstNumber, secondNumber });
                    return Ok(sum.ToString());
                }
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("multiply/{firstNumber}/{secondNumber}")]
        public IActionResult Multiply(string firstNumber, string secondNumber)
        {
            if (!string.IsNullOrEmpty(firstNumber) && !string.IsNullOrEmpty(secondNumber))
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var multiply = Operations("multiply", new List<string> { firstNumber, secondNumber });

                    return Ok(multiply.ToString());
                }
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (!string.IsNullOrEmpty(firstNumber) && !string.IsNullOrEmpty(secondNumber))
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var media = Operations("media", new List<string> { firstNumber, secondNumber }); ;

                    return Ok(media.ToString());
                }
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("substraction/{firstNumber}/{secondNumber}")]
        public IActionResult Substraction(string firstNumber, string secondNumber)
        {
            if (!string.IsNullOrEmpty(firstNumber) && !string.IsNullOrEmpty(secondNumber))
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var substraction = Operations("substraction", new List<string> { firstNumber, secondNumber });

                    return Ok(substraction.ToString());
                }
            }

            return BadRequest("Invalid Input");
        }


        [HttpGet("squareRoot/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (!string.IsNullOrEmpty(number) )
            {
                if (IsNumeric(number))
                {
                    var squareRoot = Operations("squareRoot", new List<string> { number }); 

                    return Ok(squareRoot.ToString());
                }
            }

            return BadRequest("Invalid Input");
        }


        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber,
                                    System.Globalization.NumberStyles.Any, 
                                    System.Globalization.NumberFormatInfo.InvariantInfo,
                                    out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            return decimal.Parse(strNumber);
        }


        private string Operations(string operationType, List<string> listNumber)
        {
            var result = string.Empty;
            switch (operationType)
            {
                case "sum":
                    if(listNumber.Count == 2)
                        result = (ConvertToDecimal(listNumber.ElementAt(0)) + ConvertToDecimal(listNumber.ElementAt(1))).ToString();
                    break;
                case "multiply":
                    if (listNumber.Count == 2)
                        result = (ConvertToDecimal(listNumber.ElementAt(0)) * ConvertToDecimal(listNumber.ElementAt(1))).ToString();
                    break;
                case "squareRoot":
                    if (listNumber.Count == 1)
                        result = Math.Sqrt((double)(ConvertToDecimal(listNumber.ElementAt(0)))).ToString();
                    break;
                case "substraction":
                    if (listNumber.Count == 2)
                        result = (ConvertToDecimal(listNumber.ElementAt(0)) - ConvertToDecimal(listNumber.ElementAt(1))).ToString();
                    break;
                case "media":
                    if (listNumber.Count == 2)
                        result = ((ConvertToDecimal(listNumber.ElementAt(0)) + ConvertToDecimal(listNumber.ElementAt(1)))/2).ToString();
                    break;
                case "division":
                    if (listNumber.Count == 2)
                        result = (ConvertToDecimal(listNumber.ElementAt(0)) / ConvertToDecimal(listNumber.ElementAt(1))).ToString();
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
