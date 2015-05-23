/*
 * Created by SharpDevelop.
 * User: Mouli
 * Date: 5/23/2015
 * Time: 10:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TopCoder2015
{
	class Program
	{		
		public string MultiplyNumbers(string number1, string number2)
		{
			if (number1.Length == 1 && number2.Length == 1)
			{
				return MultiplySingleDigitNumber(number1[0], number2[0]);
			}
			
			if (number2.Length > number1.Length)
			{
				string temp = number2;
				number2 = number1;
				number1 = temp;
			}
			
			if (number2.Length == 1)
			{
				int midNumber = Math.Abs(number1.Length/2);
				return AddNumbers(
					MultiplyByPowerOfTen(
						MultiplyNumbers(number1.Substring(0, midNumber), number2),
						number1.Length-midNumber
					),
					MultiplyNumbers(number1.Substring(midNumber), number2)
				);
			}
			
			int num1Length = number1.Length;
			int num1Mid = Math.Abs(num1Length/2);
			int num2Length = number2.Length;
			int num2Mid = Math.Abs(num2Length/2);
			
			string a=number1.Substring(0, num1Mid);
			string b=number1.Substring(num1Mid);
			string c=number2.Substring(0, num2Mid);
			string d=number2.Substring(num2Mid);
			
			string ac = MultiplyNumbers(a, c);
			string bd = MultiplyNumbers(b, d);
			string ad = MultiplyNumbers(a, d);
			string bc = MultiplyNumbers(b, c);
			
			return 
				AddNumbers(
					AddNumbers(
						MultiplyByPowerOfTen(ac, (num1Length-num1Mid) + (num2Length-num2Mid)),
						bd
					),
					AddNumbers(
						MultiplyByPowerOfTen(ad, (num1Length-num1Mid)),
						MultiplyByPowerOfTen(bc, (num2Length-num2Mid))
					)
				);
		}
		
		private string AddNumbers(string number1, string number2)
		{
			string result = string.Empty;
			int remainder = 0;
			for (int index=0; index<Math.Max(number1.Length, number2.Length); index++)
			{
				int num1CurrentDigit = 0;
				int num2CurrentDigit = 0;
				if (index < number1.Length)
				{
					num1CurrentDigit = number1[number1.Length - index - 1]-'0';
				}
				if (index < number2.Length)
				{
					num2CurrentDigit = number2[number2.Length - index - 1]-'0';
				}
				result = Convert.ToString((remainder + num1CurrentDigit + num2CurrentDigit)%10) + result;
				remainder = Math.Abs((remainder + num1CurrentDigit + num2CurrentDigit)/10);
			}
			if (remainder != 0)
			{
				result = remainder + result;
			}
			
			return result;
		}

		private string MultiplySingleDigitNumber(char number1, char number2)
		{
			int number1Value = number1-'0';
			int number2Value = number2-'0';
			int result = 0;

			for (int index=0; index<number1Value; index++)
				result += number2Value;
			
			return result.ToString();
		}

		private string SubtractNumbers(string number1, string number2)
		{
			string result = string.Empty;
			int remainder = 0;
			for (int index=0; index<Math.Max(number1.Length, number2.Length); index++)
			{
				int num1CurrentDigit = 0;
				int num2CurrentDigit = 0;
				if (index < number1.Length)
				{
					num1CurrentDigit = number1[number1.Length - index - 1]-'0';
				}
				if (index < number2.Length)
				{
					num2CurrentDigit = number2[number2.Length - index - 1]-'0';
				}
				result = Convert.ToString((10 + remainder + num1CurrentDigit - num2CurrentDigit)%10) + result;
				
				remainder = (remainder + num1CurrentDigit) < num2CurrentDigit ? -1 : 0;
			}
			
			if (remainder != 0) result = "-" + result;
			
			return result;
		}
		
		private string MultiplyByPowerOfTen(string number, int powerOfTen)
		{
			return String.Concat(number, new String('0', powerOfTen));
		}
		
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			string number1 = "123456789123456789123456789123456789123456789123456789123456789123456789";
			string number2 = "987654321987654321987654321987654321987654321987654321987654321987654321";
			
			Console.WriteLine(new Program().MultiplyNumbers(number1, number2));
			Console.WriteLine(Convert.ToDouble(number1) * Convert.ToDouble(number2));
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}