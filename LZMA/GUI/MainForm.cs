using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace LZMA
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel stsAddress;
		private System.Windows.Forms.StatusBarPanel stsAddress2;
		private System.Windows.Forms.RadioButton rdCompact;
		private System.Windows.Forms.RadioButton rdDescompact;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			InitializeComponent();
			//string[] s = {"e","Test.txt"};
			//lzma.Main1(s);
			//LZMA.DataStructure.Lzma.Main1(s);
		}

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
			this.btnOpen = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.stsAddress = new System.Windows.Forms.StatusBarPanel();
			this.stsAddress2 = new System.Windows.Forms.StatusBarPanel();
			this.rdCompact = new System.Windows.Forms.RadioButton();
			this.rdDescompact = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.stsAddress)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stsAddress2)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(16, 16);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(75, 48);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "&Open";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 111);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.stsAddress,
																						  this.stsAddress2});
			this.statusBar1.Size = new System.Drawing.Size(288, 22);
			this.statusBar1.TabIndex = 7;
			// 
			// stsAddress
			// 
			this.stsAddress.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.stsAddress.Text = "Address";
			this.stsAddress.Width = 80;
			// 
			// stsAddress2
			// 
			this.stsAddress2.Text = "endreco do arquivo";
			this.stsAddress2.Width = 400;
			// 
			// rdCompact
			// 
			this.rdCompact.Checked = true;
			this.rdCompact.Location = new System.Drawing.Point(128, 16);
			this.rdCompact.Name = "rdCompact";
			this.rdCompact.TabIndex = 8;
			this.rdCompact.TabStop = true;
			this.rdCompact.Text = "Compactar";
			// 
			// rdDescompact
			// 
			this.rdDescompact.Location = new System.Drawing.Point(128, 40);
			this.rdDescompact.Name = "rdDescompact";
			this.rdDescompact.TabIndex = 9;
			this.rdDescompact.Text = "Descompactar";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 133);
			this.Controls.Add(this.rdDescompact);
			this.Controls.Add(this.rdCompact);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.btnOpen);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "CompacterFile";
			((System.ComponentModel.ISupportInitialize)(this.stsAddress)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stsAddress2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				statusBar1.ShowPanels = true;
				stsAddress2.Text = openFileDialog1.FileName;
			}
			if(rdCompact.Checked)
			{
				string instream = openFileDialog1.FileName;
				string outstream = openFileDialog1.FileName.Insert(openFileDialog1.FileName.Length-3,"bia");
				outstream =  outstream.Remove(outstream.Length-3,3);
				System.Console.WriteLine("OUTSTREAM: "+outstream);
				string[] s = {"e",instream,outstream};
				LZMA.DataStructure.Lzma.Main1(s);

				stsAddress.Width = 100;
				stsAddress.Text = "Concluído";
				stsAddress2.Width = 300;
				stsAddress2.Text = outstream;
			}
			else if(rdDescompact.Checked)
			{
				string instream = openFileDialog1.FileName;
				string outstream = openFileDialog1.FileName.Insert(openFileDialog1.FileName.Length-3,"txt");
				outstream =  outstream.Remove(outstream.Length-3,3);
				System.Console.WriteLine("OUTSTREAM: "+outstream);
				string[] s = {"d",instream,outstream};
				LZMA.DataStructure.Lzma.Main1(s);

				stsAddress.Width = 100;
				stsAddress.Text = "Concluído";
				stsAddress2.Width = 300;
				stsAddress2.Text = outstream;
			}
			//progressBar1.Value =100;
		}


	}
}
