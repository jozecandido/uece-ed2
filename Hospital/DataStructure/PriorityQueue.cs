using System;
using System.Collections;

using Hospital.Entity;

namespace Hospital.DataStructure
{
	/// <summary>
	/// Summary description for PriorityQueue.
	/// </summary>
	public class PriorityQueue
	{
		
		private ArrayList queue;
	
		public int COUNT
		{
			get
			{
				return queue.Count;
			}
		}

		public Patient FIRST
		{
			get
			{
				Patient p = new Patient();
				if(queue.Count>0)
				{
					p = (Patient)queue[0];
					delete(p);
				}
				return p;
			}
		}

		
		public PriorityQueue()
		{
			queue = new ArrayList();
		}

		//Busca na fila
		private int search(Patient patient)
		{
			int result = -1;
			for(int i=0;i<queue.Count; i++)
			{
				Patient queuePatient = (Patient) queue[i];
				if(patient.IDENTITY.Equals( queuePatient.IDENTITY ))
					result = i;
			}

			return result;
		}

		public Patient getPatient(int index)
		{
			return (Patient) queue[index];
		}

		public bool inserir( Patient patient)
		{
			bool result = true;
			if(search(patient) == -1)
			{
				bool sucess = false;
				for(int i=0; i<queue.Count; i++)
				{
					Patient queuePatient = (Patient)queue[i];
					if(queuePatient.PRIORITY > patient.PRIORITY)
					{
						queue.Insert(i,getNewReference(patient));
						sucess = true;
						break;
					}
				}
	
				if(!sucess)
				{
					queue.Add(getNewReference(patient));
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool delete(Patient patient)
		{
			bool reuslt = false;
			for(int i = 0; i <queue.Count; i++)
			{
				Patient queuePatient = (Patient) queue[i];
				if(patient.IDENTITY.Equals(queuePatient.IDENTITY))
				{
					queue.RemoveAt(i);
					reuslt = true;
					break;
				}
			}
			return reuslt;
		}

		private Patient getNewReference(Patient patient)
		{
			Patient newPatient = new Patient();
			newPatient.ATTENDED = patient.ATTENDED;
			newPatient.DISEASE = patient.DISEASE;
			newPatient.IDENTITY = patient.IDENTITY;
			newPatient.PRIORITY = patient.PRIORITY;
			newPatient.TIME = patient.TIME;

			return newPatient;
		}

	}
}

