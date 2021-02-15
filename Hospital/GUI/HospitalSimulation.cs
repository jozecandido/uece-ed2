using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Hospital;
using Hospital.Commom;
using Hospital.DataStructure;

using Hospital.Entity;

namespace Hospital
{
	
	public class HospitalSimulation : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label lblSpeciality5;
		private System.Windows.Forms.Label lblSpeciality4;
		private System.Windows.Forms.Label lblSpeciality2;
		private System.Windows.Forms.Label lblSpeciality1;
		private System.Windows.Forms.Label lblSpeciality3;
		private System.Windows.Forms.Label lblDisease5;
		private System.Windows.Forms.Label lblDisease4;
		private System.Windows.Forms.Label lblDisease2;
		private System.Windows.Forms.Label lblDisease1;
		private System.Windows.Forms.Label lblDisease3;
		private System.Windows.Forms.Label lblClinico;
		private System.Windows.Forms.Label lblPediatra;
		private System.Windows.Forms.Label lblGastrologista;
		private System.Windows.Forms.Label lblOftalmologista;
		private System.Windows.Forms.Label lblCardilogista;
		private System.Windows.Forms.Label lblCase5;
		private System.Windows.Forms.Label lblCase4;
		private System.Windows.Forms.Label lblCase3;
		private System.Windows.Forms.Label lblCase2;
		private System.Windows.Forms.Label lblCase1;
		private System.Windows.Forms.Label lblObservation;
		private System.Windows.Forms.Label lblObservationText;
		private System.Windows.Forms.DataGrid dtgResult;
		private System.Windows.Forms.Label lblTimeText;
		private System.Windows.Forms.Label lblSimulation;
		private System.Windows.Forms.Label lblTimeSimulation;
		private System.Windows.Forms.TextBox txtDays;
		private System.Windows.Forms.Button btnPause;
		private System.Windows.Forms.Label lblSeparator;
		private System.Windows.Forms.Label lblLegend;
		private System.Windows.Forms.GroupBox gbConfiguration;
		private System.Windows.Forms.Label lblVelocity;
		private System.Windows.Forms.Label lblSlowVelocity;
		private System.Windows.Forms.Label lblHighVelocity;
		private System.Windows.Forms.HScrollBar hsbVelocity;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label lblDisease;
		private System.Windows.Forms.Label lblSpeciality;
		private System.Windows.Forms.Timer timerTime;
		private System.Windows.Forms.GroupBox gbLegend;
		private System.Windows.Forms.Panel pnlSimulation;
		private System.Windows.Forms.Button btnReset;

		private enum Colors {Goldenrod, DarkBlue, DarkGreen, DarkRed, Snow};
		private bool atualizar;
		private HospitalConfig config;
		private ArrayList professionals;
		private ArrayList patients;
		private int day;
		private int hour;
		private int minuts;
		private double fatorChegada;
		private double acumularChegada;
		private int blow;
		private const int HOUR = 24;
		private const int MINUTS = 60;
		private const int TIME_INTERVAL = 2001;
		private const int TIME_FACTOR = 20;
		private const int MIN_IN_DAY = 1440;
		private const string BAD_ATTENDENCE = "Devemos reavaliar o quadro de funcionários";
		private const string GOOD_ATTENDENCE = "O nível de atendimento é bom!";
		private System.Windows.Forms.Panel pnlHospitalQueue;
		private int identifier;
		private Form myParent;


		public HospitalSimulation(MainForm form)
		{
			myParent = form;
			InitializeComponent();
			config = HospitalConfig.getInstance();
			initDtgResult();
			professionals = new ArrayList();
			patients = new ArrayList();
			identifier = 0;
			createProfessionals();
			statusConstrols(true,true,false,false);
		}

		private void createProfessionals()
		{
			Array SpecialityVals = Enum.GetValues(typeof(HospitalConfig.Speciality));

			foreach(HospitalConfig.Speciality speciality in SpecialityVals)
			{
				int i = Convert.ToInt32(config.getQuantityProfessional(speciality));
				for(;i>0;i--)
				{
					Professional professional = new Professional();
					professional.IDENTITY = "" + speciality + i;
					professional.SPECIALITY = speciality;
					professionals.Add(professional);
				}
			}
		}

		private void initDtgResult()
		{
			DataTable result = new DataTable("Result");
			result.DefaultView.AllowDelete = false;
			result.DefaultView.AllowNew = false;
			result.DefaultView.AllowEdit = false;

			DataColumn dc = new DataColumn("Especialidades");
			dc.ReadOnly = true;
		
			result.Columns.Add(dc);
			result.Columns.Add(new DataColumn("Caso 1"));
			result.Columns.Add(new DataColumn("Caso 2"));
			result.Columns.Add(new DataColumn("Caso 3"));
			result.Columns.Add(new DataColumn("Caso 4"));
			result.Columns.Add(new DataColumn("Caso 5"));

			Array diseaseVals = Enum.GetValues(typeof(HospitalConfig.Disease));
			Array SpecialityVals = Enum.GetValues(typeof(HospitalConfig.Speciality));

			foreach(HospitalConfig.Speciality speciality in SpecialityVals)
			{
				DataRow dr = result.NewRow();
				int index = 0;
				dr.BeginEdit();
				dr[index++] = speciality;
				foreach(HospitalConfig.Disease disease in diseaseVals)
				{
					dr[index++] = config.getResult(speciality,disease);
				}
				dr.EndEdit();
				result.Rows.Add(dr);
			}
			result.AcceptChanges();
			dtgResult.DataSource = result;
		}

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
			this.components = new System.ComponentModel.Container();
			this.lblDisease = new System.Windows.Forms.Label();
			this.lblSpeciality = new System.Windows.Forms.Label();
			this.gbLegend = new System.Windows.Forms.GroupBox();
			this.lblCase5 = new System.Windows.Forms.Label();
			this.lblCase4 = new System.Windows.Forms.Label();
			this.lblCase3 = new System.Windows.Forms.Label();
			this.lblCase2 = new System.Windows.Forms.Label();
			this.lblCase1 = new System.Windows.Forms.Label();
			this.lblCardilogista = new System.Windows.Forms.Label();
			this.lblGastrologista = new System.Windows.Forms.Label();
			this.lblOftalmologista = new System.Windows.Forms.Label();
			this.lblPediatra = new System.Windows.Forms.Label();
			this.lblClinico = new System.Windows.Forms.Label();
			this.lblDisease5 = new System.Windows.Forms.Label();
			this.lblDisease4 = new System.Windows.Forms.Label();
			this.lblDisease2 = new System.Windows.Forms.Label();
			this.lblDisease1 = new System.Windows.Forms.Label();
			this.lblDisease3 = new System.Windows.Forms.Label();
			this.lblSpeciality5 = new System.Windows.Forms.Label();
			this.lblSpeciality4 = new System.Windows.Forms.Label();
			this.lblSpeciality2 = new System.Windows.Forms.Label();
			this.lblSpeciality1 = new System.Windows.Forms.Label();
			this.lblSpeciality3 = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.lblTimeSimulation = new System.Windows.Forms.Label();
			this.txtDays = new System.Windows.Forms.TextBox();
			this.lblObservation = new System.Windows.Forms.Label();
			this.pnlSimulation = new System.Windows.Forms.Panel();
			this.timerTime = new System.Windows.Forms.Timer(this.components);
			this.lblObservationText = new System.Windows.Forms.Label();
			this.dtgResult = new System.Windows.Forms.DataGrid();
			this.lblTimeText = new System.Windows.Forms.Label();
			this.lblSimulation = new System.Windows.Forms.Label();
			this.btnPause = new System.Windows.Forms.Button();
			this.lblSeparator = new System.Windows.Forms.Label();
			this.lblLegend = new System.Windows.Forms.Label();
			this.gbConfiguration = new System.Windows.Forms.GroupBox();
			this.lblVelocity = new System.Windows.Forms.Label();
			this.lblSlowVelocity = new System.Windows.Forms.Label();
			this.lblHighVelocity = new System.Windows.Forms.Label();
			this.hsbVelocity = new System.Windows.Forms.HScrollBar();
			this.btnReset = new System.Windows.Forms.Button();
			this.pnlHospitalQueue = new System.Windows.Forms.Panel();
			this.gbLegend.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgResult)).BeginInit();
			this.gbConfiguration.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblDisease
			// 
			this.lblDisease.BackColor = System.Drawing.Color.AliceBlue;
			this.lblDisease.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDisease.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblDisease.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblDisease.Location = new System.Drawing.Point(16, 145);
			this.lblDisease.Name = "lblDisease";
			this.lblDisease.Size = new System.Drawing.Size(144, 16);
			this.lblDisease.TabIndex = 1;
			this.lblDisease.Text = "Enfermidades";
			this.lblDisease.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSpeciality
			// 
			this.lblSpeciality.BackColor = System.Drawing.Color.AliceBlue;
			this.lblSpeciality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblSpeciality.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblSpeciality.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblSpeciality.Location = new System.Drawing.Point(16, 18);
			this.lblSpeciality.Name = "lblSpeciality";
			this.lblSpeciality.Size = new System.Drawing.Size(144, 16);
			this.lblSpeciality.TabIndex = 0;
			this.lblSpeciality.Text = "Médicos";
			this.lblSpeciality.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gbLegend
			// 
			this.gbLegend.BackColor = System.Drawing.Color.LightSteelBlue;
			this.gbLegend.Controls.Add(this.lblCase5);
			this.gbLegend.Controls.Add(this.lblCase4);
			this.gbLegend.Controls.Add(this.lblCase3);
			this.gbLegend.Controls.Add(this.lblCase2);
			this.gbLegend.Controls.Add(this.lblCase1);
			this.gbLegend.Controls.Add(this.lblCardilogista);
			this.gbLegend.Controls.Add(this.lblGastrologista);
			this.gbLegend.Controls.Add(this.lblOftalmologista);
			this.gbLegend.Controls.Add(this.lblPediatra);
			this.gbLegend.Controls.Add(this.lblClinico);
			this.gbLegend.Controls.Add(this.lblDisease5);
			this.gbLegend.Controls.Add(this.lblDisease4);
			this.gbLegend.Controls.Add(this.lblDisease2);
			this.gbLegend.Controls.Add(this.lblDisease1);
			this.gbLegend.Controls.Add(this.lblDisease3);
			this.gbLegend.Controls.Add(this.lblSpeciality5);
			this.gbLegend.Controls.Add(this.lblSpeciality4);
			this.gbLegend.Controls.Add(this.lblSpeciality2);
			this.gbLegend.Controls.Add(this.lblSpeciality1);
			this.gbLegend.Controls.Add(this.lblSpeciality);
			this.gbLegend.Controls.Add(this.lblDisease);
			this.gbLegend.Controls.Add(this.lblSpeciality3);
			this.gbLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.gbLegend.ForeColor = System.Drawing.Color.MidnightBlue;
			this.gbLegend.Location = new System.Drawing.Point(8, 40);
			this.gbLegend.Name = "gbLegend";
			this.gbLegend.Size = new System.Drawing.Size(168, 272);
			this.gbLegend.TabIndex = 0;
			this.gbLegend.TabStop = false;
			// 
			// lblCase5
			// 
			this.lblCase5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblCase5.Location = new System.Drawing.Point(48, 244);
			this.lblCase5.Name = "lblCase5";
			this.lblCase5.Size = new System.Drawing.Size(112, 16);
			this.lblCase5.TabIndex = 28;
			this.lblCase5.Text = "Caso 5";
			// 
			// lblCase4
			// 
			this.lblCase4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblCase4.Location = new System.Drawing.Point(48, 225);
			this.lblCase4.Name = "lblCase4";
			this.lblCase4.Size = new System.Drawing.Size(112, 16);
			this.lblCase4.TabIndex = 27;
			this.lblCase4.Text = "Caso 4";
			// 
			// lblCase3
			// 
			this.lblCase3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblCase3.Location = new System.Drawing.Point(48, 206);
			this.lblCase3.Name = "lblCase3";
			this.lblCase3.Size = new System.Drawing.Size(112, 16);
			this.lblCase3.TabIndex = 26;
			this.lblCase3.Text = "Caso 3";
			// 
			// lblCase2
			// 
			this.lblCase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblCase2.Location = new System.Drawing.Point(48, 187);
			this.lblCase2.Name = "lblCase2";
			this.lblCase2.Size = new System.Drawing.Size(112, 16);
			this.lblCase2.TabIndex = 25;
			this.lblCase2.Text = "Caso 2";
			// 
			// lblCase1
			// 
			this.lblCase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblCase1.Location = new System.Drawing.Point(48, 168);
			this.lblCase1.Name = "lblCase1";
			this.lblCase1.Size = new System.Drawing.Size(112, 16);
			this.lblCase1.TabIndex = 24;
			this.lblCase1.Text = "Caso 1";
			// 
			// lblCardilogista
			// 
			this.lblCardilogista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblCardilogista.Location = new System.Drawing.Point(48, 116);
			this.lblCardilogista.Name = "lblCardilogista";
			this.lblCardilogista.Size = new System.Drawing.Size(112, 16);
			this.lblCardilogista.TabIndex = 23;
			this.lblCardilogista.Text = "Cardiologista";
			// 
			// lblGastrologista
			// 
			this.lblGastrologista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblGastrologista.Location = new System.Drawing.Point(48, 97);
			this.lblGastrologista.Name = "lblGastrologista";
			this.lblGastrologista.Size = new System.Drawing.Size(112, 16);
			this.lblGastrologista.TabIndex = 22;
			this.lblGastrologista.Text = "Gastrologista";
			// 
			// lblOftalmologista
			// 
			this.lblOftalmologista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblOftalmologista.Location = new System.Drawing.Point(48, 78);
			this.lblOftalmologista.Name = "lblOftalmologista";
			this.lblOftalmologista.Size = new System.Drawing.Size(112, 16);
			this.lblOftalmologista.TabIndex = 21;
			this.lblOftalmologista.Text = "Oftalmologista";
			// 
			// lblPediatra
			// 
			this.lblPediatra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblPediatra.Location = new System.Drawing.Point(48, 59);
			this.lblPediatra.Name = "lblPediatra";
			this.lblPediatra.Size = new System.Drawing.Size(112, 16);
			this.lblPediatra.TabIndex = 20;
			this.lblPediatra.Text = "Pediatra";
			// 
			// lblClinico
			// 
			this.lblClinico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblClinico.Location = new System.Drawing.Point(48, 40);
			this.lblClinico.Name = "lblClinico";
			this.lblClinico.Size = new System.Drawing.Size(112, 16);
			this.lblClinico.TabIndex = 19;
			this.lblClinico.Text = "Clínico";
			// 
			// lblDisease5
			// 
			this.lblDisease5.BackColor = System.Drawing.Color.Snow;
			this.lblDisease5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDisease5.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDisease5.Location = new System.Drawing.Point(16, 244);
			this.lblDisease5.Name = "lblDisease5";
			this.lblDisease5.Size = new System.Drawing.Size(16, 16);
			this.lblDisease5.TabIndex = 18;
			// 
			// lblDisease4
			// 
			this.lblDisease4.BackColor = System.Drawing.Color.DarkRed;
			this.lblDisease4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDisease4.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDisease4.Location = new System.Drawing.Point(16, 225);
			this.lblDisease4.Name = "lblDisease4";
			this.lblDisease4.Size = new System.Drawing.Size(16, 16);
			this.lblDisease4.TabIndex = 17;
			// 
			// lblDisease2
			// 
			this.lblDisease2.BackColor = System.Drawing.Color.DarkBlue;
			this.lblDisease2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDisease2.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDisease2.Location = new System.Drawing.Point(16, 187);
			this.lblDisease2.Name = "lblDisease2";
			this.lblDisease2.Size = new System.Drawing.Size(16, 16);
			this.lblDisease2.TabIndex = 15;
			// 
			// lblDisease1
			// 
			this.lblDisease1.BackColor = System.Drawing.Color.Goldenrod;
			this.lblDisease1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDisease1.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDisease1.Location = new System.Drawing.Point(16, 168);
			this.lblDisease1.Name = "lblDisease1";
			this.lblDisease1.Size = new System.Drawing.Size(16, 16);
			this.lblDisease1.TabIndex = 14;
			// 
			// lblDisease3
			// 
			this.lblDisease3.BackColor = System.Drawing.Color.DarkGreen;
			this.lblDisease3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDisease3.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDisease3.Location = new System.Drawing.Point(16, 206);
			this.lblDisease3.Name = "lblDisease3";
			this.lblDisease3.Size = new System.Drawing.Size(16, 16);
			this.lblDisease3.TabIndex = 16;
			// 
			// lblSpeciality5
			// 
			this.lblSpeciality5.BackColor = System.Drawing.Color.Snow;
			this.lblSpeciality5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblSpeciality5.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSpeciality5.Location = new System.Drawing.Point(16, 116);
			this.lblSpeciality5.Name = "lblSpeciality5";
			this.lblSpeciality5.Size = new System.Drawing.Size(16, 16);
			this.lblSpeciality5.TabIndex = 13;
			// 
			// lblSpeciality4
			// 
			this.lblSpeciality4.BackColor = System.Drawing.Color.DarkRed;
			this.lblSpeciality4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblSpeciality4.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSpeciality4.Location = new System.Drawing.Point(16, 97);
			this.lblSpeciality4.Name = "lblSpeciality4";
			this.lblSpeciality4.Size = new System.Drawing.Size(16, 16);
			this.lblSpeciality4.TabIndex = 12;
			// 
			// lblSpeciality2
			// 
			this.lblSpeciality2.BackColor = System.Drawing.Color.DarkBlue;
			this.lblSpeciality2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblSpeciality2.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSpeciality2.Location = new System.Drawing.Point(16, 59);
			this.lblSpeciality2.Name = "lblSpeciality2";
			this.lblSpeciality2.Size = new System.Drawing.Size(16, 16);
			this.lblSpeciality2.TabIndex = 3;
			// 
			// lblSpeciality1
			// 
			this.lblSpeciality1.BackColor = System.Drawing.Color.Goldenrod;
			this.lblSpeciality1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblSpeciality1.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSpeciality1.Location = new System.Drawing.Point(16, 40);
			this.lblSpeciality1.Name = "lblSpeciality1";
			this.lblSpeciality1.Size = new System.Drawing.Size(16, 16);
			this.lblSpeciality1.TabIndex = 2;
			// 
			// lblSpeciality3
			// 
			this.lblSpeciality3.BackColor = System.Drawing.Color.DarkGreen;
			this.lblSpeciality3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblSpeciality3.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSpeciality3.Location = new System.Drawing.Point(16, 78);
			this.lblSpeciality3.Name = "lblSpeciality3";
			this.lblSpeciality3.Size = new System.Drawing.Size(16, 16);
			this.lblSpeciality3.TabIndex = 11;
			// 
			// btnStart
			// 
			this.btnStart.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnStart.ForeColor = System.Drawing.Color.MidnightBlue;
			this.btnStart.Location = new System.Drawing.Point(8, 424);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(168, 23);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "Iniciar";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// lblTimeSimulation
			// 
			this.lblTimeSimulation.AutoSize = true;
			this.lblTimeSimulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblTimeSimulation.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblTimeSimulation.Location = new System.Drawing.Point(12, 32);
			this.lblTimeSimulation.Name = "lblTimeSimulation";
			this.lblTimeSimulation.Size = new System.Drawing.Size(111, 16);
			this.lblTimeSimulation.TabIndex = 2;
			this.lblTimeSimulation.Text = "Tempo de Simulação:";
			// 
			// txtDays
			// 
			this.txtDays.Location = new System.Drawing.Point(132, 30);
			this.txtDays.Name = "txtDays";
			this.txtDays.Size = new System.Drawing.Size(24, 20);
			this.txtDays.TabIndex = 3;
			this.txtDays.Text = "1";
			// 
			// lblObservation
			// 
			this.lblObservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.lblObservation.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblObservation.Location = new System.Drawing.Point(208, 488);
			this.lblObservation.Name = "lblObservation";
			this.lblObservation.Size = new System.Drawing.Size(72, 16);
			this.lblObservation.TabIndex = 7;
			this.lblObservation.Text = "Observação:";
			// 
			// pnlSimulation
			// 
			this.pnlSimulation.BackColor = System.Drawing.Color.LightGray;
			this.pnlSimulation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlSimulation.Location = new System.Drawing.Point(208, 40);
			this.pnlSimulation.Name = "pnlSimulation";
			this.pnlSimulation.Size = new System.Drawing.Size(488, 232);
			this.pnlSimulation.TabIndex = 9;
			// 
			// timerTime
			// 
			this.timerTime.Interval = 1000;
			this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
			// 
			// lblObservationText
			// 
			this.lblObservationText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblObservationText.Location = new System.Drawing.Point(280, 488);
			this.lblObservationText.Name = "lblObservationText";
			this.lblObservationText.Size = new System.Drawing.Size(408, 16);
			this.lblObservationText.TabIndex = 11;
			// 
			// dtgResult
			// 
			this.dtgResult.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dtgResult.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dtgResult.BackgroundColor = System.Drawing.Color.LightGray;
			this.dtgResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtgResult.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.dtgResult.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgResult.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgResult.CaptionText = "Resultado do Atendimento";
			this.dtgResult.DataMember = "";
			this.dtgResult.FlatMode = true;
			this.dtgResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgResult.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgResult.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dtgResult.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dtgResult.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.dtgResult.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.dtgResult.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dtgResult.LinkColor = System.Drawing.Color.Teal;
			this.dtgResult.Location = new System.Drawing.Point(208, 360);
			this.dtgResult.Name = "dtgResult";
			this.dtgResult.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dtgResult.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dtgResult.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dtgResult.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dtgResult.Size = new System.Drawing.Size(485, 123);
			this.dtgResult.TabIndex = 12;
			// 
			// lblTimeText
			// 
			this.lblTimeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTimeText.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblTimeText.Location = new System.Drawing.Point(616, 8);
			this.lblTimeText.Name = "lblTimeText";
			this.lblTimeText.Size = new System.Drawing.Size(80, 24);
			this.lblTimeText.TabIndex = 15;
			this.lblTimeText.Text = "00:00:00";
			// 
			// lblSimulation
			// 
			this.lblSimulation.AutoSize = true;
			this.lblSimulation.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblSimulation.Location = new System.Drawing.Point(208, 16);
			this.lblSimulation.Name = "lblSimulation";
			this.lblSimulation.Size = new System.Drawing.Size(57, 16);
			this.lblSimulation.TabIndex = 16;
			this.lblSimulation.Text = "Simulação";
			// 
			// btnPause
			// 
			this.btnPause.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnPause.ForeColor = System.Drawing.Color.MidnightBlue;
			this.btnPause.Location = new System.Drawing.Point(8, 456);
			this.btnPause.Name = "btnPause";
			this.btnPause.Size = new System.Drawing.Size(168, 23);
			this.btnPause.TabIndex = 18;
			this.btnPause.Text = "Pausar";
			this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// lblSeparator
			// 
			this.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblSeparator.Location = new System.Drawing.Point(192, 16);
			this.lblSeparator.Name = "lblSeparator";
			this.lblSeparator.Size = new System.Drawing.Size(3, 512);
			this.lblSeparator.TabIndex = 19;
			// 
			// lblLegend
			// 
			this.lblLegend.AutoSize = true;
			this.lblLegend.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblLegend.Location = new System.Drawing.Point(8, 16);
			this.lblLegend.Name = "lblLegend";
			this.lblLegend.Size = new System.Drawing.Size(48, 16);
			this.lblLegend.TabIndex = 20;
			this.lblLegend.Text = "Legenda";
			// 
			// gbConfiguration
			// 
			this.gbConfiguration.BackColor = System.Drawing.Color.LightSteelBlue;
			this.gbConfiguration.Controls.Add(this.txtDays);
			this.gbConfiguration.Controls.Add(this.lblTimeSimulation);
			this.gbConfiguration.ForeColor = System.Drawing.Color.MidnightBlue;
			this.gbConfiguration.Location = new System.Drawing.Point(8, 336);
			this.gbConfiguration.Name = "gbConfiguration";
			this.gbConfiguration.Size = new System.Drawing.Size(168, 72);
			this.gbConfiguration.TabIndex = 21;
			this.gbConfiguration.TabStop = false;
			this.gbConfiguration.Text = "Configuração";
			// 
			// lblVelocity
			// 
			this.lblVelocity.AutoSize = true;
			this.lblVelocity.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblVelocity.Location = new System.Drawing.Point(208, 320);
			this.lblVelocity.Name = "lblVelocity";
			this.lblVelocity.Size = new System.Drawing.Size(64, 16);
			this.lblVelocity.TabIndex = 22;
			this.lblVelocity.Text = "Velocidade:";
			// 
			// lblSlowVelocity
			// 
			this.lblSlowVelocity.AutoSize = true;
			this.lblSlowVelocity.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblSlowVelocity.Location = new System.Drawing.Point(320, 320);
			this.lblSlowVelocity.Name = "lblSlowVelocity";
			this.lblSlowVelocity.Size = new System.Drawing.Size(33, 16);
			this.lblSlowVelocity.TabIndex = 23;
			this.lblSlowVelocity.Text = "Baixa";
			// 
			// lblHighVelocity
			// 
			this.lblHighVelocity.AutoSize = true;
			this.lblHighVelocity.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lblHighVelocity.Location = new System.Drawing.Point(672, 320);
			this.lblHighVelocity.Name = "lblHighVelocity";
			this.lblHighVelocity.Size = new System.Drawing.Size(24, 16);
			this.lblHighVelocity.TabIndex = 25;
			this.lblHighVelocity.Text = "Alta";
			// 
			// hsbVelocity
			// 
			this.hsbVelocity.Location = new System.Drawing.Point(360, 320);
			this.hsbVelocity.Maximum = 109;
			this.hsbVelocity.Name = "hsbVelocity";
			this.hsbVelocity.Size = new System.Drawing.Size(312, 16);
			this.hsbVelocity.SmallChange = 10;
			this.hsbVelocity.TabIndex = 26;
			this.hsbVelocity.Value = 50;
			this.hsbVelocity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbVelocity_Scroll);
			// 
			// btnReset
			// 
			this.btnReset.BackColor = System.Drawing.Color.LightSteelBlue;
			this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnReset.ForeColor = System.Drawing.Color.MidnightBlue;
			this.btnReset.Location = new System.Drawing.Point(8, 488);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(168, 23);
			this.btnReset.TabIndex = 27;
			this.btnReset.Text = "Resetar";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// pnlHospitalQueue
			// 
			this.pnlHospitalQueue.BackColor = System.Drawing.Color.LightGray;
			this.pnlHospitalQueue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlHospitalQueue.Location = new System.Drawing.Point(208, 272);
			this.pnlHospitalQueue.Name = "pnlHospitalQueue";
			this.pnlHospitalQueue.Size = new System.Drawing.Size(488, 40);
			this.pnlHospitalQueue.TabIndex = 28;
			// 
			// HospitalSimulation
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.GhostWhite;
			this.ClientSize = new System.Drawing.Size(712, 542);
			this.Controls.Add(this.pnlHospitalQueue);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.hsbVelocity);
			this.Controls.Add(this.lblHighVelocity);
			this.Controls.Add(this.lblSlowVelocity);
			this.Controls.Add(this.lblVelocity);
			this.Controls.Add(this.gbConfiguration);
			this.Controls.Add(this.lblLegend);
			this.Controls.Add(this.lblSeparator);
			this.Controls.Add(this.btnPause);
			this.Controls.Add(this.lblSimulation);
			this.Controls.Add(this.dtgResult);
			this.Controls.Add(this.lblObservationText);
			this.Controls.Add(this.pnlSimulation);
			this.Controls.Add(this.lblObservation);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.gbLegend);
			this.Controls.Add(this.lblTimeText);
			this.MaximizeBox = false;
			this.Name = "HospitalSimulation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "HospitalSimulation";
			this.Closed += new System.EventHandler(this.HospitalSimulation_Closed);
			this.gbLegend.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtgResult)).EndInit();
			this.gbConfiguration.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private Color getColorBySpeciality(HospitalConfig.Speciality speciality)
		{
			switch(speciality)
			{
				case HospitalConfig.Speciality.Clinico : return Color.Goldenrod;
				case HospitalConfig.Speciality.Pediatra : return Color.MidnightBlue;
				case HospitalConfig.Speciality.Oftalmologista : return Color.DarkGreen; 
				case HospitalConfig.Speciality.Gastrologista : return Color.DarkRed;
				case HospitalConfig.Speciality.Cardiologista : return Color.Snow;
			}

			return Color.Black;
		}

		private Color getColorByDisease(HospitalConfig.Disease disease)
		{
			switch(disease)
			{
				case HospitalConfig.Disease.Case1 : return Color.Goldenrod;
				case HospitalConfig.Disease.Case2 : return Color.MidnightBlue;
				case HospitalConfig.Disease.Case3 : return Color.DarkGreen; 
				case HospitalConfig.Disease.Case4 : return Color.DarkRed;
				case HospitalConfig.Disease.Case5 : return Color.Snow;
			}

			return Color.Black;
		}
		
		private double getRandom()
		{
			Random random = new Random();
			return random.NextDouble();
		}
		private HospitalConfig.Disease getRandomDisease()
		{
			Random random = new Random();

			switch(Convert.ToInt32(random.NextDouble()*5))
			{
				case 0 : return HospitalConfig.Disease.Case1;
				case 1 : return HospitalConfig.Disease.Case2;
				case 2 : return HospitalConfig.Disease.Case3;
				case 3 : return HospitalConfig.Disease.Case4;
				case 4 : return HospitalConfig.Disease.Case5;
			}
			return HospitalConfig.Disease.Case1;
		}

		private double getFatorCarga()
		{
			double result;
			result = getRandom()*config.MAX_PATIENT +1;
			if(result<config.MIN_PATIENT)
			{
				result = config.MIN_PATIENT;
			}
			result /= MIN_IN_DAY;

			return result;
		}

		private void statusConstrols(bool enTxtDays, bool enBtnStart, bool enBtnPause, bool enBtnReset)
		{
			txtDays.Enabled = enTxtDays;
			btnStart.Enabled = enBtnStart;
			btnPause.Enabled = enBtnPause;
			btnReset.Enabled = enBtnReset;
		}

		private void entrance()
		{
			acumularChegada += fatorChegada;
			int num = 0;
			Random random = new Random(identifier);
			if( acumularChegada>1)
			{
				num = Convert.ToInt32(getRandom()*acumularChegada);
				acumularChegada -= num;
			}
			for( int i=0; i < num;i++)
			{
				atualizar = true;
				HospitalConfig.Disease[] diseases =  (HospitalConfig.Disease[])Enum.GetValues(typeof(HospitalConfig.Disease));
				Patient patient = new Patient();
				patient.IDENTITY = "" + identifier.ToString("0000");
				identifier++;
				patient.DISEASE =  diseases[random.Next(5)];
				insertPatient(patient);
				patients.Add(patient);
			}
			fatorChegada = getFatorCarga();
		}

		private void insertPatient(Patient patient)
		{
			atualizar = true;
			
			foreach(Professional professional in professionals)
			{
				patient.PRIORITY = config.getPriority(professional.SPECIALITY, patient.DISEASE);
				patient.TIME = config.getTime(professional.SPECIALITY, patient.DISEASE);
				if(!patient.PRIORITY.Equals(0))
				{
					if(professional.QUEUE.COUNT>=1)			
					{
						blow++;
					}
					bool insert = false;
					while(!insert)
					{
						insert = professional.QUEUE.inserir(patient);
						if(!insert)
						{
							patient.IDENTITY = ""+identifier++;
						}
						else
						{
							break;
						}
					}
				}
			}
		}

		public void deletePatient(Patient patient)
		{
			atualizar = true;
			foreach(Professional professional in professionals)
			{

				professional.QUEUE.delete(patient);
					
			}
			for(int i = 0; i < patients.Count; i++)
			{
				Patient patientInQueue = (Patient) patients[i];
				if(patient.IDENTITY.Equals(patientInQueue.IDENTITY))
				{
					patients.RemoveAt(i);
				}
			}
		}

		private void attend(Professional professional)
		{
			if(professional.QUEUE.COUNT>0)
			{
				Patient patient = professional.attendNewPatient();
				blow--;
				professional.ISFREE = false;
				patient.ATTENDED = true;
				config.setResult(patient.DISEASE, professional.SPECIALITY);
				deletePatient(patient);
				atualizar = true;
			}
		}

		private void run()
		{
			foreach(Professional professional in professionals)
			{
				if(professional.ISFREE)
					if(professional.QUEUE.COUNT>0)
						if(professional.QUEUE.getPatient(0).DISEASE.Equals(config.specialityDisease(professional.SPECIALITY)))
							attend(professional);
			}
			foreach(Professional professional in professionals)
			{
				if(professional.ISFREE)
				{
					attend(professional);
				}
				else
				{
					professional.attend();
					if(professional.ISFREE)
						attend(professional);
				}
			}
		}

		private void adjustTime()
		{
			
			if(!minuts.Equals(0))
			{
				minuts--;
			}
			else if(!hour.Equals(0))
			{
				minuts = MINUTS;
				hour--;
			}
			else if(!day.Equals(0))
			{
				hour = HOUR;
				day--;
			}
			else
			{
				minuts = 0;
				hour = 0;
			}
			lblTimeText.Text = "" + day.ToString("00") + ":" + hour.ToString("00") + ":" + minuts.ToString("00");
		}

		private void setTimerStatus(bool enable)
		{
			if(enable)
				timerTime.Start();
			else
				timerTime.Stop();
		}

		private void paint()
		{
			Graphics graphSim = pnlSimulation.CreateGraphics();
			Graphics graphQueue = pnlHospitalQueue.CreateGraphics();
			graphSim.Clear(Color.LightGray);
			graphQueue.Clear(Color.LightGray);
			Font font = new Font("Verdana",8.0f);
			Pen pen = new Pen(Color.Black);
			int x = 20; 
			int y;
			foreach(Professional professional in professionals)
			{
				y = 20;
				pen.Color = getColorBySpeciality(professional.SPECIALITY);
				graphSim.FillRectangle(pen.Brush,x-10,y-10,10,10);
				pen.Color = Color.Black;
				graphSim.DrawLine(pen,x + 25,0,x+25,60);
				if(!professional.ISFREE)
				{
					pen.Color = getColorByDisease(professional.PATIENT.DISEASE);
					graphSim.FillEllipse(pen.Brush,x-10,y+5,15,15);
					pen.Color = Color.Black;
					graphSim.DrawString(professional.PATIENT.IDENTITY, font,pen.Brush, (float) (x-10),(float)(y+18) );
					graphSim.DrawString("T :" + professional.PATIENT.TIME.ToString(), font,pen.Brush,x-10,y+28);
				}
				if(atualizar)
				{
					y = 100;
					pen.Color = Color.Black;
					graphSim.DrawLine(pen,x+25,70,x+25,300);
					for(int i=0; i<professional.QUEUE.COUNT; i++)
					{
						Patient patient = professional.QUEUE.getPatient(i);
						pen.Color = getColorByDisease(patient.DISEASE);
						graphSim.FillEllipse(pen.Brush,x-10,y-10,15,15);
						pen.Color = Color.Black;
						graphSim.DrawString(patient.IDENTITY,font,pen.Brush,x-10,y);
						graphSim.DrawString("Pr:" + patient.PRIORITY,font,pen.Brush,x-10,y+12);
						y += 40;
					}
				}
				x += 40;
			}
			x = 10;
			y = 5;
			for(int i=0; i<patients.Count; i++)
			{
				
				Patient patient  = (Patient)patients[i];
				pen.Color = getColorByDisease(patient.DISEASE);
				graphQueue.FillEllipse(pen.Brush,x-10,y+10, 10, 10);
				pen.Color = Color.Black;
				graphQueue.DrawString(patient.IDENTITY,font,pen.Brush,x-10,y+10);
				x +=40;
			}
		}

		private void clear()
		{
			lblTimeText.Text = "00:00:00";
			lblObservationText.Text="";
			pnlSimulation.CreateGraphics().Clear(Color.LightGray);
			pnlHospitalQueue.CreateGraphics().Clear(Color.LightGray);
		}

		private void timerTime_Tick(object sender, System.EventArgs e)
		{
			entrance();
			run();
			adjustTime();
			paint();
			if( (day.Equals(0)) && (hour.Equals(0)) && (minuts.Equals(0)) )
			{
				setTimerStatus(false);
				statusConstrols(true,true,false,false);
			}
			if(blow>0)
			{
				lblObservationText.Text = BAD_ATTENDENCE;
			}
			else
			{
				lblObservationText.Text = GOOD_ATTENDENCE;
			}
			if(patients.Count>0)
			{
				lblObservationText.Text += " Ainda temos " + patients.Count.ToString() + " pacientes na fila." ;
			}
			initDtgResult();
		}

		private void btnStart_Click(object sender, System.EventArgs e)
		{
			minuts = MINUTS;
			hour = HOUR;
			int day = 0;
			try
			{
				day = (Convert.ToInt32(txtDays.Text));
				if(day>=1) day--;
			}
			finally
			{
				this.day = day;
			}
			Random random = new Random();
			fatorChegada = getFatorCarga();
			acumularChegada = 0;
			setTimerStatus(true);
			statusConstrols(false,false,true,true);
		}

		private void btnPause_Click(object sender, System.EventArgs e)
		{
			if(btnPause.Text == "Pausar")
			{
				btnPause.Text = "Continuar";
				setTimerStatus(false);
			}
			else
			{
				btnPause.Text = "Pausar";
				setTimerStatus(true);
			}
			
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			config.clearResult();
			professionals = new ArrayList();
			patients = new ArrayList();
			identifier = 0;
			createProfessionals();
			statusConstrols(true,true,false,false);
			initDtgResult();
			setTimerStatus(false);
			clear();
			
		}

		private void hsbVelocity_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			timerTime.Interval = TIME_INTERVAL-hsbVelocity.Value*TIME_FACTOR;
		}

		private void HospitalSimulation_Closed(object sender, System.EventArgs e)
		{
			btnReset_Click(sender,e);
			this.Hide();
			myParent.ShowInTaskbar = true;
			myParent.Show();
		}

	}

}
