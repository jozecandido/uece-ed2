using System;
using System.Collections;

namespace Hospital.Commom
{
	/// <summary>
	/// Summary description for HospitalConfig.
	/// </summary>
	public class HospitalConfig
	{

		private Hashtable priority;
		private Hashtable time;
		private Hashtable quantProfessional;
		private Hashtable result;
		private int maxPatient;
		private int minPatient;
		private static HospitalConfig config;
		
		public int MAX_PATIENT
		{
			get
			{
				return maxPatient;
			}
			set
			{
				maxPatient = value;
			}
		}

		public int MIN_PATIENT
		{
			get
			{
				return minPatient;
			}
			set
			{
				minPatient = value;
			}
		}

		public enum Disease{Case1,Case2,Case3,Case4,Case5}
		public enum Speciality {Clinico, Pediatra, Oftalmologista, Gastrologista, Cardiologista}

		private HospitalConfig()
		{
			minPatient = 200;
			maxPatient = 800;
			initPriorityHT();
			initTimeHT();
			initQuantProfessionalHT();
			initResultHT();
		}

		public Disease specialityDisease(Speciality speciality)
		{
			Disease disease = Disease.Case1;
			switch(speciality)
			{
				case Speciality.Clinico : disease = Disease.Case1;
					break;
				case Speciality.Pediatra : disease = Disease.Case2;
					break;
				case Speciality.Oftalmologista : disease = Disease.Case3;
					break;
				case Speciality.Gastrologista : disease = Disease.Case4;
					break;
				case Speciality.Cardiologista : disease = Disease.Case5;
					break;
			}
			return disease;
		}

		public Speciality diseaseSpeciality(Disease disease)
		{
			Speciality speciality = Speciality.Clinico;
			switch(disease)
			{
				case Disease.Case1 : speciality = Speciality.Clinico;
					break;
				case Disease.Case2 : speciality = Speciality.Pediatra;
					break;
				case Disease.Case3 : speciality = Speciality.Oftalmologista;
					break;
				case Disease.Case4 : speciality = Speciality.Gastrologista;
					break;
				case Disease.Case5 : speciality = Speciality.Cardiologista;
					break;
			}
			return speciality;
		}

		public static HospitalConfig getInstance()
		{
			if(config == null)
			{
				config = new HospitalConfig();
			}
			return config;
		}

		public int getResult(Speciality speciality,Disease disease)
		{
			return (int) result[""+speciality+disease];
		}

		public void setResult(Disease disease, Speciality speciality)
		{
			this.result[""+speciality+disease] = Convert.ToInt32(result[""+speciality+disease])+ 1;
		}
		public void clearResult()
		{
			initResultHT();
		}

		public int getQuantityProfessional(Speciality speciality)
		{
			return (int) quantProfessional[""+speciality];
		}

		public void setQuantityProfessional(Speciality speciality, int quantity)
		{
			if((quantity>=0) && (quantity<10))
			{
				this.quantProfessional[""+speciality] = quantity;
			}
			else
			{
				switch(speciality)
				{
					case Speciality.Cardiologista : quantProfessional[""+speciality] = 1;
						break;
					case Speciality.Clinico : quantProfessional[""+speciality] = 5;
						break;
					case Speciality.Gastrologista : quantProfessional[""+speciality] = 1;
						break;
					case Speciality.Oftalmologista : quantProfessional[""+speciality] = 1;
						break;
					case Speciality.Pediatra : quantProfessional[""+speciality] = 3;
						break;
				}
			}
		}

		public int getPriority(Speciality speciality,Disease disease)
		{
			return (int) priority[""+speciality+disease];
		}

		public void setPriority(Disease disease, Speciality speciality, int priority)
		{
			if((priority>=0) && (priority<6))
			{
				this.priority[""+speciality+disease] = priority;
			}
			else
			{
				this.priority[""+speciality+disease] = 1;
			}
		}

		public int getTime(Speciality speciality,Disease disease)
		{
			return (int) time[""+speciality+disease];
		}

		public void setTime(Disease disease, Speciality speciality, int time)
		{
			if((time>0) && (time<100))
			{
				this.time[""+speciality+disease] = time;
			}
			else
			{
				this.time[""+speciality+disease] = 15;
			}
		}

		private void initQuantProfessionalHT()
		{
			quantProfessional = new Hashtable();
			
			quantProfessional.Add(""+Speciality.Cardiologista, 1);
			quantProfessional.Add(""+Speciality.Clinico, 5);
			quantProfessional.Add(""+Speciality.Gastrologista, 1);
			quantProfessional.Add(""+Speciality.Oftalmologista, 1);
			quantProfessional.Add(""+Speciality.Pediatra, 3);
		}

		private void initResultHT()
		{
			result = new Hashtable();
			// Speciality.Cardiologista
			result.Add((""+Speciality.Cardiologista+Disease.Case1),0);
			result.Add((""+Speciality.Cardiologista+Disease.Case2),0);
			result.Add((""+Speciality.Cardiologista+Disease.Case3),0);
			result.Add((""+Speciality.Cardiologista+Disease.Case4),0);
			result.Add((""+Speciality.Cardiologista+Disease.Case5),0);

			// Speciality.Clinico
			result.Add((""+Speciality.Clinico+Disease.Case1),0);
			result.Add((""+Speciality.Clinico+Disease.Case2),0);
			result.Add((""+Speciality.Clinico+Disease.Case3),0);
			result.Add((""+Speciality.Clinico+Disease.Case4),0);
			result.Add((""+Speciality.Clinico+Disease.Case5),0);

			// Speciality.Gastrologista
			result.Add((""+Speciality.Gastrologista+Disease.Case1),0);
			result.Add((""+Speciality.Gastrologista+Disease.Case2),0);
			result.Add((""+Speciality.Gastrologista+Disease.Case3),0);
			result.Add((""+Speciality.Gastrologista+Disease.Case4),0);
			result.Add((""+Speciality.Gastrologista+Disease.Case5),0);

			// Speciality.Oftalmologista
			result.Add((""+Speciality.Oftalmologista+Disease.Case1),0);
			result.Add((""+Speciality.Oftalmologista+Disease.Case2),0);
			result.Add((""+Speciality.Oftalmologista+Disease.Case3),0);
			result.Add((""+Speciality.Oftalmologista+Disease.Case4),0);
			result.Add((""+Speciality.Oftalmologista+Disease.Case5),0);

			// Speciality.Pediatra
			result.Add((""+Speciality.Pediatra+Disease.Case1),0);
			result.Add((""+Speciality.Pediatra+Disease.Case2),0);
			result.Add((""+Speciality.Pediatra+Disease.Case3),0);
			result.Add((""+Speciality.Pediatra+Disease.Case4),0);
			result.Add((""+Speciality.Pediatra+Disease.Case5),0);
		}

		private void initPriorityHT()
		{
			priority = new Hashtable();
			// Speciality.Cardiologista
			priority.Add((""+Speciality.Cardiologista+Disease.Case1),4);
			priority.Add((""+Speciality.Cardiologista+Disease.Case2),3);
			priority.Add((""+Speciality.Cardiologista+Disease.Case3),5);
			priority.Add((""+Speciality.Cardiologista+Disease.Case4),3);
			priority.Add((""+Speciality.Cardiologista+Disease.Case5),1);

			// Speciality.Clinico
			priority.Add((""+Speciality.Clinico+Disease.Case1),1);
			priority.Add((""+Speciality.Clinico+Disease.Case2),2);
			priority.Add((""+Speciality.Clinico+Disease.Case3),4);
			priority.Add((""+Speciality.Clinico+Disease.Case4),2);
			priority.Add((""+Speciality.Clinico+Disease.Case5),3);

			// Speciality.Gastrologista
			priority.Add((""+Speciality.Gastrologista+Disease.Case1),4);
			priority.Add((""+Speciality.Gastrologista+Disease.Case2),3);
			priority.Add((""+Speciality.Gastrologista+Disease.Case3),5);
			priority.Add((""+Speciality.Gastrologista+Disease.Case4),1);
			priority.Add((""+Speciality.Gastrologista+Disease.Case5),5);

			// Speciality.Oftalmologista
			priority.Add((""+Speciality.Oftalmologista+Disease.Case1),5);
			priority.Add((""+Speciality.Oftalmologista+Disease.Case2),4);
			priority.Add((""+Speciality.Oftalmologista+Disease.Case3),1);
			priority.Add((""+Speciality.Oftalmologista+Disease.Case4),4);
			priority.Add((""+Speciality.Oftalmologista+Disease.Case5),5);

			// Speciality.Pediatra
			priority.Add((""+Speciality.Pediatra+Disease.Case1),3);
			priority.Add((""+Speciality.Pediatra+Disease.Case2),1);
			priority.Add((""+Speciality.Pediatra+Disease.Case3),5);
			priority.Add((""+Speciality.Pediatra+Disease.Case4),3);
			priority.Add((""+Speciality.Pediatra+Disease.Case5),5);
		}

		private void initTimeHT()
		{
			time = new Hashtable();
			// Speciality.Cardiologista
			time.Add((""+Speciality.Cardiologista+Disease.Case1),40);
			time.Add((""+Speciality.Cardiologista+Disease.Case2),30);
			time.Add((""+Speciality.Cardiologista+Disease.Case3),50);
			time.Add((""+Speciality.Cardiologista+Disease.Case4),35);
			time.Add((""+Speciality.Cardiologista+Disease.Case5),15);

			// Speciality.Clinico
			time.Add((""+Speciality.Clinico+Disease.Case1),15);
			time.Add((""+Speciality.Clinico+Disease.Case2),20);
			time.Add((""+Speciality.Clinico+Disease.Case3),40);
			time.Add((""+Speciality.Clinico+Disease.Case4),20);
			time.Add((""+Speciality.Clinico+Disease.Case5),30);

			// Speciality.Gastrologista
			time.Add((""+Speciality.Gastrologista+Disease.Case1),40);
			time.Add((""+Speciality.Gastrologista+Disease.Case2),30);
			time.Add((""+Speciality.Gastrologista+Disease.Case3),55);
			time.Add((""+Speciality.Gastrologista+Disease.Case4),15);
			time.Add((""+Speciality.Gastrologista+Disease.Case5),50);

			// Speciality.Oftalmologista
			time.Add((""+Speciality.Oftalmologista+Disease.Case1),50);
			time.Add((""+Speciality.Oftalmologista+Disease.Case2),40);
			time.Add((""+Speciality.Oftalmologista+Disease.Case3),15);
			time.Add((""+Speciality.Oftalmologista+Disease.Case4),40);
			time.Add((""+Speciality.Oftalmologista+Disease.Case5),50);

			// Speciality.Pediatra
			time.Add((""+Speciality.Pediatra+Disease.Case1),30);
			time.Add((""+Speciality.Pediatra+Disease.Case2),15);
			time.Add((""+Speciality.Pediatra+Disease.Case3),50);
			time.Add((""+Speciality.Pediatra+Disease.Case4),30);
			time.Add((""+Speciality.Pediatra+Disease.Case5),50);
		}
	}
}
