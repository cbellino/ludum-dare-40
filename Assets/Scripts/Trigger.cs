using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public struct TriggerParam
	{
		public GameObject source;
		public Collider collider;
	}

	public class Trigger : MonoBehaviour
	{
		void OnTriggerEnter(Collider collider)
		{	
			var param = new TriggerParam { collider = collider, source = gameObject };
			SendMessageUpwards("OnChildTriggerEnter", param);
		}
	}
}