using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class Water : MonoBehaviour
	{
		public Collider attractCollider;
		public Transform attractionTarget;

		void OnChildTriggerEnter (TriggerParam param)
		{
			if (param.source.name == attractCollider.name)
			{
				if (param.collider.gameObject.tag == "Firefly" && param.collider.name == "Attract Collider")
				{
					param.collider.gameObject.SendMessageUpwards("AttractedByWater", attractionTarget);
				}
			}
		}
	}
}
