/*
 * Created by SharpDevelop.
 * User: Mouli
 * Date: 6/7/2015
 * Time: 12:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TopCoder2015
{
	/// <summary>
	/// Description of ABCPath.
	/// </summary>
	public class ABCPath
	{
		public int length(string[] grid)
		{
			var maxLength = 0;
			
			for (int strIndex=0; strIndex<grid.Length; strIndex++)
			{
				for (int charIndex=0; charIndex<grid[strIndex].Length; charIndex++)
				{
					if (grid[strIndex][charIndex] == 'A')
					{
						var length = CalculateLength(grid, strIndex, charIndex, 'A', 1);
						if (length > maxLength)
						{
							maxLength = length;
						}
					}
				}
			}
			
			return maxLength;
		}
		
		public int CalculateLength(string[] grid, int strIndex, int charIndex, char currentChar, int currentLength)
		{
			if ((strIndex>0) && (charIndex>0) && (grid[strIndex-1][charIndex-1] == currentChar + 1))
			{
				return CalculateLength(grid, strIndex-1, charIndex-1, (char)((int)currentChar+1), currentLength+1);
			}
			if ((charIndex>0) && (grid[strIndex][charIndex-1] == currentChar + 1))
			{
				return CalculateLength(grid, strIndex, charIndex-1, (char)((int)currentChar+1), currentLength+1);
			}
			if ((strIndex<grid.Length-1) && (charIndex>0) && (grid[strIndex+1][charIndex-1] == currentChar + 1))
			{
				return CalculateLength(grid, strIndex+1, charIndex-1, (char)((int)currentChar+1), currentLength+1);
			}
			if ((strIndex<grid.Length-1) && (grid[strIndex+1][charIndex] == currentChar + 1))
			{
				return CalculateLength(grid, strIndex+1, charIndex, (char)((int)currentChar+1), currentLength+1);
			}
			if ((strIndex<grid.Length-1) && (charIndex<grid[strIndex].Length-1) && (grid[strIndex+1][charIndex+1] == currentChar + 1))
			{
				return CalculateLength(grid, strIndex+1, charIndex+1, (char)((int)currentChar+1), currentLength+1);
			}
			if ((charIndex<grid[strIndex].Length-1) && (grid[strIndex][charIndex+1] == currentChar + 1))
			{
				return CalculateLength(grid, strIndex, charIndex+1, (char)((int)currentChar+1), currentLength+1);
			}
			if ((strIndex>0) && (charIndex<grid[strIndex].Length-1) && (grid[strIndex-1][charIndex+1] == currentChar + 1))
			{
				return CalculateLength(grid, strIndex-1, charIndex+1, (char)((int)currentChar+1), currentLength+1);
			}
			if ((strIndex>0) && (grid[strIndex-1][charIndex] == currentChar + 1))
			{
				return CalculateLength(grid, strIndex-1, charIndex, (char)((int)currentChar+1), currentLength+1);
			}
			
			return currentLength;
		}
		
		public static void ABCPathMain(string[] args)
		{
			var strArray = new []{"AMNOPA", "ALEFQR", "KDABGS", "AJCHUT", "AAIWVA", "AZYXAA" };
			Console.WriteLine(new ABCPath().length(strArray));
		}
	}
}
