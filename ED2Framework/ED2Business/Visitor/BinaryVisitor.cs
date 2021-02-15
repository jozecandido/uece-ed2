using System;
using System.Collections;
using ED2DataStructures.Trees.Binary;

namespace ED2Business.Visitor
{
	/// <summary>
	/// Summary description for BinaryVisitor.
	/// </summary>
	public class BinaryVisitor
	{
		private Hashtable points;
		private int[] levelsCount;

		public BinaryVisitor(AbstractBinaryTree tree)
		{
			points = new Hashtable();
			if(tree != null)
			levelsCount = new int[tree.HEIGHT+1];
			initPointsHT(tree);
			
		}
		
		private void initPointsHT(AbstractBinaryTree tree)
		{
			if(tree.KEY!=null)
			{
				points.Add(tree.KEY.VALUE, ""+tree.HEIGHT+"."+levelsCount[tree.HEIGHT]);
				levelsCount[tree.HEIGHT]++;
				initPointsHT(tree.getLeftChild());
				initPointsHT(tree.getRightChild());
			}
		}

		public int[] getPoint(String key)
		{
			String val = (String) points[key];
			String[] splited = val.Split('.');
			int[] result = new int[]{Convert.ToInt32(splited[0]),Convert.ToInt32(splited[1])};
			return result;
		}

	}
}
