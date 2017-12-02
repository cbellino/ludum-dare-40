using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class Water : MonoBehaviour
	{
		public Collider attractCollider;

		void OnChildTriggerEnter (TriggerParam param)
		{	
			if (param.source.name == attractCollider.name)
			{
				if (param.collider.gameObject.tag == "Firefly")
				{
					Debug.Log("Firefly entered water.");
				}
			}
		}

	}
}