using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Hospital.Commom;

namespace Hospital
{
	/*
	 *	1. Clínico Geral - 5 médicos
		2. Pediatra/Obstetra - 3 médicos
		3. Oftalmologista - 1 médico
		4. Gastroclínico - 1 médico
		5. Cirurgião Cardiaco - 1 médico
	 * 
	 * */
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dtgPriority;
		private static MainForm mainForm;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.DataGrid dtgTime;
		private Point currentPriorityPos;
		private System.Windows.Forms.DataGrid dtgQuantProfessional;
		private System.Windows.Forms.DataGrid dtgNumPatient;
		private System.Windows.Forms.Button btnInitSimulation;


		private HospitalConfig config;

		public MainForm()
		{
			InitializeComponent();
			currentPriorityPos = new Point();
			config = HospitalConfig.getInstance();
			initDtgPriority();
			initDtgTime();
			initQuantityProfessional();
			initNumberPatient();
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
		
		private void InitializeComponent()
		{
			this.btnInitSimulation = new System.Windows.Forms.Button();
			this.dtgPriority = new System.Windows.Forms.DataGrid();
			this.dtgTime = new System.Windows.Forms.DataGrid();
			this.dtgQuantProfessional = new System.Windows.Forms.DataGrid();
			this.dtgNumPatient = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dtgPriority)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgQuantProfessional)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgNumPatient)).BeginInit();
			this.SuspendLayout();
			// 
			// btnInitSimulation
			// 
			this.btnInitSimulation.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnInitSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnInitSimulation.ForeColor = System.Drawing.Color.MidnightBlue;
			this.btnInitSimulation.Location = new System.Drawing.Point(8, 256);
			this.btnInitSimulation.Name = "btnInitSimulation";
			this.btnInitSimulation.Size = new System.Drawing.Size(184, 24);
			this.btnInitSimulation.TabIndex = 3;
			this.btnInitSimulation.Text = "Iniciar";
			this.btnInitSimulation.Click += new System.EventHandler(this.bntInitSimulation_Click);
			// 
			// dtgPriority
			// 
			this.dtgPriority.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dtgPriority.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dtgPriority.BackgroundColor = System.Drawing.Color.LightGray;
			this.dtgPriority.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtgPriority.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.dtgPriority.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgPriority.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgPriority.CaptionText = "Prioridade de Atendimento";
			this.dtgPriority.DataMember = "";
			this.dtgPriority.FlatMode = true;
			this.dtgPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgPriority.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgPriority.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dtgPriority.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dtgPriority.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.dtgPriority.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgPriority.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dtgPriority.LinkColor = System.Drawing.Color.Teal;
			this.dtgPriority.Location = new System.Drawing.Point(216, 8);
			this.dtgPriority.Name = "dtgPriority";
			this.dtgPriority.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dtgPriority.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgPriority.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dtgPriority.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dtgPriority.Size = new System.Drawing.Size(485, 123);
			this.dtgPriority.TabIndex = 5;
			// 
			// dtgTime
			// 
			this.dtgTime.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dtgTime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dtgTime.BackgroundColor = System.Drawing.Color.LightGray;
			this.dtgTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtgTime.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.dtgTime.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgTime.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgTime.CaptionText = "Tempo de Atendimento";
			this.dtgTime.DataMember = "";
			this.dtgTime.FlatMode = true;
			this.dtgTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgTime.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgTime.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dtgTime.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dtgTime.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.dtgTime.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgTime.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dtgTime.LinkColor = System.Drawing.Color.Teal;
			this.dtgTime.Location = new System.Drawing.Point(216, 152);
			this.dtgTime.Name = "dtgTime";
			this.dtgTime.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dtgTime.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgTime.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dtgTime.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dtgTime.Size = new System.Drawing.Size(485, 123);
			this.dtgTime.TabIndex = 6;
			// 
			// dtgQuantProfessional
			// 
			this.dtgQuantProfessional.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dtgQuantProfessional.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dtgQuantProfessional.BackgroundColor = System.Drawing.Color.LightGray;
			this.dtgQuantProfessional.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtgQuantProfessional.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.dtgQuantProfessional.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgQuantProfessional.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgQuantProfessional.CaptionText = "Quantidade Profissionais";
			this.dtgQuantProfessional.DataMember = "";
			this.dtgQuantProfessional.FlatMode = true;
			this.dtgQuantProfessional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgQuantProfessional.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgQuantProfessional.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dtgQuantProfessional.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dtgQuantProfessional.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.dtgQuantProfessional.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgQuantProfessional.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dtgQuantProfessional.LinkColor = System.Drawing.Color.Teal;
			this.dtgQuantProfessional.Location = new System.Drawing.Point(8, 8);
			this.dtgQuantProfessional.Name = "dtgQuantProfessional";
			this.dtgQuantProfessional.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dtgQuantProfessional.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgQuantProfessional.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dtgQuantProfessional.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dtgQuantProfessional.Size = new System.Drawing.Size(185, 123);
			this.dtgQuantProfessional.TabIndex = 7;
			// 
			// dtgNumPatient
			// 
			this.dtgNumPatient.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dtgNumPatient.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dtgNumPatient.BackgroundColor = System.Drawing.Color.LightGray;
			this.dtgNumPatient.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtgNumPatient.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.dtgNumPatient.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgNumPatient.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgNumPatient.CaptionText = "Número Pacientes";
			this.dtgNumPatient.DataMember = "";
			this.dtgNumPatient.FlatMode = true;
			this.dtgNumPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgNumPatient.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgNumPatient.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dtgNumPatient.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dtgNumPatient.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.dtgNumPatient.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgNumPatient.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dtgNumPatient.LinkColor = System.Drawing.Color.Teal;
			this.dtgNumPatient.Location = new System.Drawing.Point(8, 160);
			this.dtgNumPatient.Name = "dtgNumPatient";
			this.dtgNumPatient.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dtgNumPatient.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgNumPatient.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dtgNumPatient.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dtgNumPatient.Size = new System.Drawing.Size(185, 72);
			this.dtgNumPatient.TabIndex = 8;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.GhostWhite;
			this.ClientSize = new System.Drawing.Size(712, 285);
			this.Controls.Add(this.dtgNumPatient);
			this.Controls.Add(this.dtgQuantProfessional);
			this.Controls.Add(this.dtgTime);
			this.Controls.Add(this.dtgPriority);
			this.Controls.Add(this.btnInitSimulation);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Emergência";
			((System.ComponentModel.ISupportInitialize)(this.dtgPriority)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgQuantProfessional)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgNumPatient)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		
		[STAThread]
		static void Main() 
		{
			mainForm = new MainForm();
			Application.Run(mainForm);
		}

		private void initNumberPatient()
		{
			DataTable numPatient = new DataTable("NumberPatient");
			numPatient.DefaultView.AllowDelete = false;
			numPatient.DefaultView.AllowNew = false;

			DataColumn dc = new DataColumn("Limites");
			dc.ReadOnly = true;

			numPatient.Columns.Add(dc);
			numPatient.Columns.Add(new DataColumn("Quantidade"));
			
			DataRow drMin = numPatient.NewRow();
			drMin.BeginEdit();
			drMin[0] = "Mínimo";
			drMin[1] = config.MIN_PATIENT;
			drMin.EndEdit();
			numPatient.Rows.Add(drMin);
			
			DataRow drMax = numPatient.NewRow();
			drMax.BeginEdit();
			drMax[0] = "Máximo";
			drMax[1] = config.MAX_PATIENT;
			drMax.EndEdit();
			numPatient.Rows.Add(drMax);
			
			numPatient.AcceptChanges();
			dtgNumPatient.DataSource = numPatient;
		}

		private void initQuantityProfessional()
		{
			DataTable quantProfessional = new DataTable("QuantProfessional");
			quantProfessional.DefaultView.AllowDelete = false;
			quantProfessional.DefaultView.AllowNew = false;

			DataColumn dc = new DataColumn("Especialidades");
			dc.ReadOnly = true;

			quantProfessional.Columns.Add(dc);
			quantProfessional.Columns.Add(new DataColumn("Quantidade"));
			
			Array SpecialityVals = Enum.GetValues(typeof(HospitalConfig.Speciality));

			foreach(HospitalConfig.Speciality speciality in SpecialityVals)
			{
				DataRow dr = quantProfessional.NewRow();
				dr.BeginEdit();
				dr[0] = speciality;
				dr[1] = config.getQuantityProfessional(speciality);
				dr.EndEdit();
				quantProfessional.Rows.Add(dr);
			}
			quantProfessional.AcceptChanges();
			dtgQuantProfessional.DataSource = quantProfessional;
		}

		private void initDtgPriority()
		{
			DataTable priority = new DataTable("AttendancePriority");
			priority.DefaultView.AllowDelete = false;
			priority.DefaultView.AllowNew = false;
			DataColumn dc = new DataColumn("Especialidades");
			dc.ReadOnly = true;

			priority.Columns.Add(dc);
			priority.Columns.Add(new DataColumn("Caso 1"));
			priority.Columns.Add(new DataColumn("Caso 2"));
			priority.Columns.Add(new DataColumn("Caso 3"));
			priority.Columns.Add(new DataColumn("Caso 4"));
			priority.Columns.Add(new DataColumn("Caso 5"));

			Array diseaseVals = Enum.GetValues(typeof(HospitalConfig.Disease));
			Array SpecialityVals = Enum.GetValues(typeof(HospitalConfig.Speciality));

			foreach(HospitalConfig.Speciality speciality in SpecialityVals)
			{
				DataRow dr = priority.NewRow();
				int index = 0;
				dr.BeginEdit();
				dr[index++] = speciality;
				foreach(HospitalConfig.Disease disease in diseaseVals)
				{
					dr[index++] = config.getPriority(speciality,disease);
				}
				dr.EndEdit();
				priority.Rows.Add(dr);
			}
			priority.AcceptChanges();
			dtgPriority.DataSource = priority;
		}

		private void initDtgTime()
		{
			DataTable time = new DataTable("AttendanceTime");
			time.DefaultView.AllowDelete = false;
			time.DefaultView.AllowNew = false;

			DataColumn dc = new DataColumn("Especialidades");
			dc.ReadOnly = true;
			
			time.Columns.Add(dc);
			time.Columns.Add(new DataColumn("Caso 1"));
			time.Columns.Add(new DataColumn("Caso 2"));
			time.Columns.Add(new DataColumn("Caso 3"));
			time.Columns.Add(new DataColumn("Caso 4"));
			time.Columns.Add(new DataColumn("Caso 5"));

			Array diseaseVals = Enum.GetValues(typeof(HospitalConfig.Disease));
			Array SpecialityVals = Enum.GetValues(typeof(HospitalConfig.Speciality));

			foreach(HospitalConfig.Speciality speciality in SpecialityVals)
			{
				DataRow dr = time.NewRow();
				int index = 0;
				dr.BeginEdit();
				dr[index++] = speciality;
				foreach(HospitalConfig.Disease disease in diseaseVals)
				{
					dr[index++] = config.getTime(speciality,disease);
				}
				dr.EndEdit();
				time.Rows.Add(dr);
			}
			time.AcceptChanges();
			dtgTime.DataSource = time;
		}
		
		private void bntInitSimulation_Click(object sender, System.EventArgs e)
		{
			setPriority();
			setTime();
			setNumberPatient();
			setQuantityProfessional();
			HospitalSimulation simulation = new HospitalSimulation(mainForm);
			this.ShowInTaskbar = false;
			this.SetVisibleCore(false);
			simulation.Show();
		}

		private void setPriority()
		{
			DataTable priority  = (DataTable) dtgPriority.DataSource;

			foreach(DataRow dr in priority.Rows)
			{
				HospitalConfig.Speciality speciality =(HospitalConfig.Speciality) Enum.Parse(typeof(HospitalConfig.Speciality),(string) dr[0]);
				config.setPriority(HospitalConfig.Disease.Case1, speciality,Convert.ToInt32(dr[1]));
				config.setPriority(HospitalConfig.Disease.Case2, speciality,Convert.ToInt32(dr[2]));
				config.setPriority(HospitalConfig.Disease.Case3, speciality,Convert.ToInt32(dr[3]));
				config.setPriority(HospitalConfig.Disease.Case4, speciality,Convert.ToInt32(dr[4]));
				config.setPriority(HospitalConfig.Disease.Case5, speciality,Convert.ToInt32(dr[5]));
			}
		}

		private void setTime()
		{
			DataTable time  = (DataTable) dtgTime.DataSource;

			foreach(DataRow dr in time.Rows)
			{
				HospitalConfig.Speciality speciality =(HospitalConfig.Speciality) Enum.Parse(typeof(HospitalConfig.Speciality),(string) dr[0]);
				config.setTime(HospitalConfig.Disease.Case1, speciality,Convert.ToInt32(dr[1]));
				config.setTime(HospitalConfig.Disease.Case2, speciality,Convert.ToInt32(dr[2]));
				config.setTime(HospitalConfig.Disease.Case3, speciality,Convert.ToInt32(dr[3]));
				config.setTime(HospitalConfig.Disease.Case4, speciality,Convert.ToInt32(dr[4]));
				config.setTime(HospitalConfig.Disease.Case5, speciality,Convert.ToInt32(dr[5]));
			}
		}

		private void setQuantityProfessional()
		{
			DataTable quantProfessional  = (DataTable) dtgQuantProfessional.DataSource;

			foreach(DataRow dr in quantProfessional.Rows)
			{
				HospitalConfig.Speciality speciality =(HospitalConfig.Speciality) Enum.Parse(typeof(HospitalConfig.Speciality),(string) dr[0]);
				config.setQuantityProfessional(speciality,Convert.ToInt32(dr[1]));
			}
		}


		private void setNumberPatient()
		{
			DataTable numberPatient  = (DataTable) dtgNumPatient.DataSource;

			foreach(DataRow dr in numberPatient.Rows)
			{
				if(dr[0].ToString().Equals("Mínimo"))
					config.MIN_PATIENT = Convert.ToInt32(dr[1]);
				else
					config.MAX_PATIENT = Convert.ToInt32(dr[1]);
			}
		}

	}
}
