using System;
using Hospital.Commom;

namespace Hospital.Entity
{
	/// <summary>
	/// Summary description for Paciente.
	/// </summary>
	public class Patient
	{

		private string identity;
		private bool attended;
		private	HospitalConfig.Disease disease;
		private int time;
		private int priority;

		public bool ATTENDED
		{
			get
			{
				return attended;
			}
			set
			{
				attended = value;
			}
		}

		public string IDENTITY
		{
			get
			{
				return identity;
			}
			set
			{
				identity = value;
			}
		}

		public HospitalConfig.Disease DISEASE
		{
			get
			{
				return disease;
			}
			set
			{
				disease = value;
			}
		}

		public int TIME
		{
			get
			{
				return time;
			}
			set
			{
				time = value;
			}
		}

		public int PRIORITY
		{
			get
			{
				return priority;
			}
			set
			{
				priority = value;
			}
		}

	}
}
