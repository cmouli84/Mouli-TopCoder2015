/*
 * Created by SharpDevelop.
 * User: Mouli
 * Date: 6/7/2015
 * Time: 11:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TopCoder2015
{
	/// <summary>
	/// Description of ABC.
	/// </summary>
	public class ABC
	{
		char[] StrABC = {'A', 'B', 'C'};
		
		public string createString(int N, int K)
		{
			return getAbcString(N, K, string.Empty, 0, 0, 0);
		}
		
		private string getAbcString(int N, int K, string currentString, int aCount, int bCount, int kValue)
		{
			if (N == currentString.Length)
			{
				return (K == kValue) ? currentString : string.Empty;
			}
			
			for (int abcIndex=2; abcIndex>=0; abcIndex--)
			{
				if (abcIndex == 2)
				{
					string returnValue = getAbcString(N, K, currentString + "C", aCount, bCount, kValue+aCount+bCount);
					if (returnValue == string.Empty)
					{
						continue;
					}
					return returnValue;
				}
				if (abcIndex == 1)
				{
					string returnValue = getAbcString(N, K, currentString + "B", aCount, bCount+1, kValue+aCount);
					if (returnValue == String.Empty)
					{
						continue;
					}
					return returnValue;
				}
				if (abcIndex == 0)
				{
					string returnValue = getAbcString(N, K, currentString + "A", aCount+1, bCount, kValue);

					if (returnValue == string.Empty)
					{
						continue;
					}
					return returnValue;
				}
			}
			
			return string.Empty;			
		}
		
		public static void Main(string[] args)
		{
			Console.WriteLine(new ABC().createString(15, 36));
		}
	}
}
