/*
 * Created by SharpDevelop.
 * User: Mouli
 * Date: 6/14/2015
 * Time: 10:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TopCoder2015
{
	/// <summary>
	/// Description of EightQueen.
	/// </summary>
	public class EightQueen
	{
		public int[,] FindQueenPosition(int[,] queenPosition)
		{
			int queenLength = queenPosition.Length/2;
			if (queenLength == 8)
			{
				return queenPosition;
			}
			
			var rowIndex = 0;
			var colIndex = -1;
			if (queenLength > 0)
			{
				rowIndex=queenPosition[queenLength-1,0];
				colIndex=queenPosition[queenLength-1,1];
			}
			
			for (int i=rowIndex; i<8; i++)
			{
				int j=0;
				if (rowIndex == i)
				{
					j=colIndex+1;
				}
				for (; j<8; j++)
				{
					bool intersect = false;
					for (int k=0; k<queenLength; k++)
					{
						if (queenPosition[k,0] == i)
						{
							intersect = true;
							break;
						}
						if (queenPosition[k,1] == j)
						{
							intersect = true;
							break;
						}
						if (Math.Abs(queenPosition[k,0] - i) == Math.Abs(queenPosition[k,1] - j))
						{
							intersect = true;
							break;
						}
					}
					
					if (!intersect)
					{
						var newArray = new int[queenLength+1,2];
						
						int m=0;
						for (; m<queenLength; m++)
						{
							newArray[m, 0] = queenPosition[m, 0];
							newArray[m, 1] = queenPosition[m, 1];
						}
						newArray[m, 0] = i;
						newArray[m, 1] = j;
						
						var returnArray = FindQueenPosition(newArray);
						if (returnArray.Length/2 == 8)
						{
							return returnArray;
						}
					}
				}
			}
			
			return queenPosition;
		}
		
		public static void Main(string[] args)
		{
			var queenPosition = new int[0,2];
			queenPosition = new EightQueen().FindQueenPosition(queenPosition);
			for (int i=0; i<queenPosition.Length/2; i++)
			{
				Console.WriteLine(queenPosition[i,0] + "," + queenPosition[i,1]);
			}
		}
	}
}
