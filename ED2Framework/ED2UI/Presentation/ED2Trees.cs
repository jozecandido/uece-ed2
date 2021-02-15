using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ED2DataStructures.Trees.Binary.Implementation;
using ED2DataStructures.Trees;
using ED2Business.Handler;
using ED2Util.Config;
using ED2DataStructures.Trees.Binary;
using ED2UI.View;
using System.Drawing.Drawing2D;


namespace ED2UI.Presentation
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ED2Trees : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnInsert;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.CheckBox ckbAVL;
		private System.Windows.Forms.CheckBox ckbB;
		private System.Windows.Forms.CheckBox ckbBinary;
		private System.Windows.Forms.CheckBox ckbSplay;
		private System.Windows.Forms.Label lblOrdemText;
		private System.Windows.Forms.TextBox txtNumber;
		private System.Windows.Forms.Label lblNumber;
		private System.Windows.Forms.Panel pnlMenu;
		private ArrayList views;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ED2Trees()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			views = new ArrayList();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.txtNumber = new System.Windows.Forms.TextBox();
			this.btnInsert = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.lblNumber = new System.Windows.Forms.Label();
			this.btnSearch = new System.Windows.Forms.Button();
			this.pnlMenu = new System.Windows.Forms.Panel();
			this.lblOrdemText = new System.Windows.Forms.Label();
			this.ckbSplay = new System.Windows.Forms.CheckBox();
			this.ckbB = new System.Windows.Forms.CheckBox();
			this.ckbAVL = new System.Windows.Forms.CheckBox();
			this.ckbBinary = new System.Windows.Forms.CheckBox();
			this.pnlMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtNumber
			// 
			this.txtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNumber.Location = new System.Drawing.Point(48, 23);
			this.txtNumber.Name = "txtNumber";
			this.txtNumber.Size = new System.Drawing.Size(72, 20);
			this.txtNumber.TabIndex = 0;
			this.txtNumber.Text = "";
			// 
			// btnInsert
			// 
			this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnInsert.Location = new System.Drawing.Point(136, 22);
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.TabIndex = 1;
			this.btnInsert.Text = "Inserir";
			this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDelete.Location = new System.Drawing.Point(224, 22);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Remover";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// lblNumber
			// 
			this.lblNumber.AutoSize = true;
			this.lblNumber.Location = new System.Drawing.Point(16, 25);
			this.lblNumber.Name = "lblNumber";
			this.lblNumber.Size = new System.Drawing.Size(25, 16);
			this.lblNumber.TabIndex = 4;
			this.lblNumber.Text = "No.:";
			// 
			// btnSearch
			// 
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSearch.Location = new System.Drawing.Point(312, 22);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.TabIndex = 6;
			this.btnSearch.Text = "Buscar";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// pnlMenu
			// 
			this.pnlMenu.Controls.Add(this.lblOrdemText);
			this.pnlMenu.Controls.Add(this.ckbSplay);
			this.pnlMenu.Controls.Add(this.ckbB);
			this.pnlMenu.Controls.Add(this.ckbAVL);
			this.pnlMenu.Controls.Add(this.btnSearch);
			this.pnlMenu.Controls.Add(this.btnDelete);
			this.pnlMenu.Controls.Add(this.btnInsert);
			this.pnlMenu.Controls.Add(this.txtNumber);
			this.pnlMenu.Controls.Add(this.lblNumber);
			this.pnlMenu.Controls.Add(this.ckbBinary);
			this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlMenu.Location = new System.Drawing.Point(0, 0);
			this.pnlMenu.Name = "pnlMenu";
			this.pnlMenu.Size = new System.Drawing.Size(664, 64);
			this.pnlMenu.TabIndex = 8;
			// 
			// lblOrdemText
			// 
			this.lblOrdemText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.lblOrdemText.Location = new System.Drawing.Point(584, 32);
			this.lblOrdemText.Name = "lblOrdemText";
			this.lblOrdemText.Size = new System.Drawing.Size(64, 24);
			this.lblOrdemText.TabIndex = 12;
			// 
			// ckbSplay
			// 
			this.ckbSplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ckbSplay.Location = new System.Drawing.Point(512, 8);
			this.ckbSplay.Name = "ckbSplay";
			this.ckbSplay.Size = new System.Drawing.Size(56, 24);
			this.ckbSplay.TabIndex = 10;
			this.ckbSplay.Text = "Splay";
			this.ckbSplay.CheckedChanged += new System.EventHandler(this.ckbSplay_CheckedChanged);
			// 
			// ckbB
			// 
			this.ckbB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ckbB.Location = new System.Drawing.Point(512, 32);
			this.ckbB.Name = "ckbB";
			this.ckbB.Size = new System.Drawing.Size(24, 24);
			this.ckbB.TabIndex = 8;
			this.ckbB.Text = "B";
			// 
			// ckbAVL
			// 
			this.ckbAVL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ckbAVL.Location = new System.Drawing.Point(424, 8);
			this.ckbAVL.Name = "ckbAVL";
			this.ckbAVL.Size = new System.Drawing.Size(56, 24);
			this.ckbAVL.TabIndex = 7;
			this.ckbAVL.Text = "AVL";
			// 
			// ckbBinary
			// 
			this.ckbBinary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ckbBinary.Location = new System.Drawing.Point(424, 32);
			this.ckbBinary.Name = "ckbBinary";
			this.ckbBinary.Size = new System.Drawing.Size(64, 24);
			this.ckbBinary.TabIndex = 9;
			this.ckbBinary.Text = "Binária";
			// 
			// ED2Trees
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 422);
			this.Controls.Add(this.pnlMenu);
			this.IsMdiContainer = true;
			this.Name = "ED2Trees";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ED2Trees";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnlMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ED2Trees());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			TreeHandler th = TreeHandler.getInstance();
//			
//			th.addTree(StructureType.AVL,1);
			th.addTree(StructureType.B,1);
//			th.addTree(StructureType.BINARY,1);
		}

		private void btnInsert_Click(object sender, System.EventArgs e)
		{

			TreeHandler.getInstance().insert(txtNumber.Text);
			foreach(IView view in views)
				view.draw();
//			tree2.insertKey(new Key(textBox1.Text));
//
//			Graphics graph = panel1.CreateGraphics();
//			graph.DrawLine(new Pen(Color.DarkBlue),panel1.Bounds.Width/2,0,panel1.Bounds.Width/2,30);
//
//			graph.FillRectangle(new Pen(Color.DarkBlue).Brush,panel1.Bounds.Width/2-9*s.Length/2,30,9*s.Length,13);
//			graph.DrawRectangle(new Pen(Color.White),0,0,9*s.Length,13);
//			//Image(Image.FromFile(Application.StartupPath + "\\img\\img-1.bmp"), 0, 0);
//			graph.DrawString(s.ToUpper(),new Font("Verdana", 8,FontStyle.Bold), new Pen(Color.White).Brush,0,0);
//			
//			graph.FillRectangle(new Pen(Color.DarkBlue).Brush,0,39,9*s.Length,13);
//			graph.DrawRectangle(new Pen(Color.White),0,39,9*s.Length,13);
//			//Image(Image.FromFile(Application.StartupPath + "\\img\\img-1.bmp"), 0, 0);
//			graph.DrawString(s.ToUpper(),new Font("Verdana", 8,FontStyle.Bold), new Pen(Color.White).Brush,0,39);
			
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			TreeHandler.getInstance().delete(txtNumber.Text);
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
			
//			PictureBox img = new PictureBox();
//			img.Image = ;
//			panel1.Controls.Add(img);
//			Rectangle rec = new Rectangle();
//			System.Drawing.Drawing2D.
		}

		private void insert()
		{
			TreeHandler th = TreeHandler.getInstance();
			th.insert("60");
			th.insert("50");
			th.insert("30");
			th.insert("40");
			th.insert("55");
			th.insert("58");
			th.insert("80");
			th.insert("75");
			th.insert("45");
			th.insert("10");
			th.insert("05");
			th.insert("57");
			th.insert("42");
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			if(!"".Equals(txtNumber.Text))
				TreeHandler.getInstance().insert(txtNumber.Text);
		}

		private void ckbSplay_CheckedChanged(object sender, System.EventArgs e)
		{
			if(ckbSplay.Checked)
			{
				AbstractBinaryTree binaryTree = (AbstractBinaryTree)TreeHandler.getInstance().addTree(StructureType.SPLAY,1);
				BinaryView splayView = new BinaryView(binaryTree);
				splayView.MdiParent = this;
				views.Add(splayView);
				insert();
				splayView.Show();

				
			}
		}
	}
}
