using System;

using Hospital.DataStructure;
using Hospital.Commom;

namespace Hospital.Entity
{
	/// <summary>
	/// Summary description for Profissional.
	/// </summary>
	public class Professional
	{

		private HospitalConfig.Speciality speciality;
		private string identity;
		private Patient patient;
		private PriorityQueue queue;
		private bool free;

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
		
		public HospitalConfig.Speciality SPECIALITY
		{
			get
			{
				return speciality;
			}
			set
			{
				speciality = value;
			}
		}

		public Patient PATIENT
		{
			get
			{
				return patient;
			}
			set
			{
				patient = value;
			}
		}

		public PriorityQueue QUEUE
		{
			get
			{
				return queue;
			}
		}

		public bool ISFREE
		{
			get
			{
				return free;
			}
			set
			{
				free = value;		
			}
		}

		public Professional()
		{
			queue = new PriorityQueue();
			free = true;
		}

		public Patient attendNewPatient()
		{
			if(queue.COUNT>0)
			{
				patient = queue.FIRST;
			}
			return patient;
		}

		public void attend()
		{
			if(patient != null)
			{
				if(patient.TIME>0)
				{
					patient.TIME -= 1;
					if(0.Equals(patient.TIME))
					{
						free = true;
					}
				}
			}
		}
	}
}