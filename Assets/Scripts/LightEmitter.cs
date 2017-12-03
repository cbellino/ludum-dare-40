using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	[ExecuteInEditMode]
	public class LightEmitter : MonoBehaviour
	{
		public SpriteMask mask;
		public SphereCollider lightCollider;
		[Range(0f, 5f)]
		public float radius = 3f;

		const float lerpSpeed = 10f;

		void Update ()
		{
			Vector3 newScale = Vector3.one * radius * 2;
			mask.transform.localScale = Vector3.Lerp(mask.transform.localScale, newScale, Time.deltaTime * lerpSpeed);

			if (lightCollider)
			{
				lightCollider.radius = radius;
				lightCollider.radius = Mathf.Lerp(lightCollider.radius, radius, Time.deltaTime * lerpSpeed);
			}
		}

		public void AddLight (float amount)
		{
			radius += amount;
		}
	}
}
