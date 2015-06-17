/*
 * Created by SharpDevelop.
 * User: Mouli
 * Date: 6/17/2015
 * Time: 10:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TopCoder2015
{
	/// <summary>
	/// Description of KnightTraversal.
	/// </summary>
	public class KnightTraversal
	{
		const int BOARDSIZE = 8;
		
		public int[,] FindKnightTraversalPath(int currentPositionX, int currentPositionY, int[,] knightTraversalPath)
		{
			var traversedLength = knightTraversalPath.Length/2;
			if (traversedLength == (BOARDSIZE*BOARDSIZE))
			{
				return knightTraversalPath;
			}
			
			int newPositionX = currentPositionX-1;
			int newPositionY = currentPositionY-2;
			if (IsValidPositionToTraverse(newPositionX, newPositionY, knightTraversalPath))
		    {
				var result = FindKnightTraversalPath(newPositionX, newPositionY, GetNewArray(knightTraversalPath, newPositionX, newPositionY));
				if (result.Length == (BOARDSIZE*BOARDSIZE*2))
				{
					return result;
				}
		    }
			
			newPositionX = currentPositionX-2;
			newPositionY = currentPositionY-1;
			if (IsValidPositionToTraverse(newPositionX, newPositionY, knightTraversalPath))
		    {
				var result = FindKnightTraversalPath(newPositionX, newPositionY, GetNewArray(knightTraversalPath, newPositionX, newPositionY));
				if (result.Length == (BOARDSIZE*BOARDSIZE*2))
				{
					return result;
				}
		    }
			
			newPositionX = currentPositionX-2;
			newPositionY = currentPositionY+1;
			if (IsValidPositionToTraverse(newPositionX, newPositionY, knightTraversalPath))
		    {
				var result = FindKnightTraversalPath(newPositionX, newPositionY, GetNewArray(knightTraversalPath, newPositionX, newPositionY));
				if (result.Length == (BOARDSIZE*BOARDSIZE*2))
				{
					return result;
				}
		    }
			
			newPositionX = currentPositionX-1;
			newPositionY = currentPositionY+2;
			if (IsValidPositionToTraverse(newPositionX, newPositionY, knightTraversalPath))
		    {
				var result = FindKnightTraversalPath(newPositionX, newPositionY, GetNewArray(knightTraversalPath, newPositionX, newPositionY));
				if (result.Length == (BOARDSIZE*BOARDSIZE*2))
				{
					return result;
				}
		    }
			
			newPositionX = currentPositionX+1;
			newPositionY = currentPositionY+2;
			if (IsValidPositionToTraverse(newPositionX, newPositionY, knightTraversalPath))
		    {
				var result = FindKnightTraversalPath(newPositionX, newPositionY, GetNewArray(knightTraversalPath, newPositionX, newPositionY));
				if (result.Length == (BOARDSIZE*BOARDSIZE*2))
				{
					return result;
				}
		    }
			
			newPositionX = currentPositionX+2;
			newPositionY = currentPositionY+1;
			if (IsValidPositionToTraverse(newPositionX, newPositionY, knightTraversalPath))
		    {
				var result = FindKnightTraversalPath(newPositionX, newPositionY, GetNewArray(knightTraversalPath, newPositionX, newPositionY));
				if (result.Length == (BOARDSIZE*BOARDSIZE*2))
				{
					return result;
				}
		    }
			
			newPositionX = currentPositionX+2;
			newPositionY = currentPositionY-1;
			if (IsValidPositionToTraverse(newPositionX, newPositionY, knightTraversalPath))
		    {
				var result = FindKnightTraversalPath(newPositionX, newPositionY, GetNewArray(knightTraversalPath, newPositionX, newPositionY));
				if (result.Length == (BOARDSIZE*BOARDSIZE*2))
				{
					return result;
				}
		    }
			
			newPositionX = currentPositionX+1;
			newPositionY = currentPositionY-2;
			if (IsValidPositionToTraverse(newPositionX, newPositionY, knightTraversalPath))
		    {
				var result = FindKnightTraversalPath(newPositionX, newPositionY, GetNewArray(knightTraversalPath, newPositionX, newPositionY));
				if (result.Length == (BOARDSIZE*BOARDSIZE*2))
				{
					return result;
				}
		    }
			return knightTraversalPath;
			
		}
		
		private int[,] GetNewArray(int[,] currentArray, int newX, int newY)
		{
			var length = currentArray.Length/2;
			var newArray = new int[length+1,2];

			int m=0;
			for (; m<length; m++)
			{
				newArray[m, 0] = currentArray[m, 0];
				newArray[m, 1] = currentArray[m, 1];
			}
			newArray[m, 0] = newX;
			newArray[m, 1] = newY;	
			return newArray;
		}
		
		private bool IsValidPositionToTraverse(int positionX, int positionY, int[,] knightTraversalPath)
		{
			if (positionX < 0 || positionX >= BOARDSIZE) return false;
			if (positionY < 0 || positionY >= BOARDSIZE) return false;
			
			for (int i=0; i<knightTraversalPath.Length/2; i++)
			{
				if ((knightTraversalPath[i,0] == positionX) && (knightTraversalPath[i,1] == positionY)) return false;
			}
			return true;
		}
		
		public static void Main(string[] args)
		{
			var knightTraversalPath = new int[1,2]{{0,0}};
			knightTraversalPath = new KnightTraversal().FindKnightTraversalPath(0, 0, knightTraversalPath);
			for (int i=0; i<knightTraversalPath.Length/2; i++)
			{
				Console.WriteLine(knightTraversalPath[i,0] + "," + knightTraversalPath[i,1]);
			}
		}
	}
}
