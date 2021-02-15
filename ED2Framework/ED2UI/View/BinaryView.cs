using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using ED2Business.Visitor;
using ED2DataStructures.Trees.Binary;

namespace ED2UI.View
{
	/// <summary>
	/// Summary description for BinaryView.
	/// </summary>
	public class BinaryView : System.Windows.Forms.Form, IView
	{
		private System.Windows.Forms.Panel pnlStatus;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Graphics panelGraph;
		private Font defFont;
		private Pen blackPen;
		private Pen whitePen;
		private Pen treePen;
		private Pen alterTreePen;
		private AbstractBinaryTree tree;
		private BinaryVisitor binVis;
		private int MAX_HEIGHT;
		private int MAX_WIDTH;
		private static int HEIGHT = 16;
		private static int height;

		public BinaryView(AbstractBinaryTree tree)
		{
			InitializeComponent();
			this.tree = tree;
			panelGraph = this.CreateGraphics();
			defFont = new Font("Verdana",8.0f);
			blackPen = new Pen(Color.Black);
			whitePen = new Pen(Color.White);
			treePen = new Pen(Color.LightGray);
			alterTreePen = new Pen(Color.Gray);
			MAX_HEIGHT = this.Height;
			MAX_WIDTH = Width;
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pnlStatus = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// pnlStatus
			// 
			this.pnlStatus.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.pnlStatus.Location = new System.Drawing.Point(8, 8);
			this.pnlStatus.Name = "pnlStatus";
			this.pnlStatus.Size = new System.Drawing.Size(120, 24);
			this.pnlStatus.TabIndex = 0;
			// 
			// BinaryView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(608, 438);
			this.Controls.Add(this.pnlStatus);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BinaryView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "BinaryView";
			this.Click += new System.EventHandler(this.BinaryView_Click);
			this.ResumeLayout(false);

		}
		#endregion

		private void drawNode(string key,int x, int y)
		{
			panelGraph.DrawRectangle(blackPen,x,y,key.Length*7 + 7,HEIGHT);
			panelGraph.FillRectangle(treePen.Brush,x,y,key.Length*7 + 7,HEIGHT);
			panelGraph.DrawString( key,defFont,whitePen.Brush,x+5,y);
		}

		public void drawTree(AbstractBinaryTree tree)
		{
			if(tree.KEY != null)
			{
				height++;
				int[] point = binVis.getPoint(tree.KEY.VALUE);
				drawNode(tree.KEY.VALUE,MAX_WIDTH/height,point[1]);
				drawTree(tree.getLeftChild());

			}
		}

		public void draw()
		{
			binVis = new BinaryVisitor(tree);
			drawTree(tree);
		}

		private void BinaryView_Click(object sender, System.EventArgs e)
		{
			draw();
		}
	}
}
