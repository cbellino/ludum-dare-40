using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	[ExecuteInEditMode]
	public class LightEmitter : MonoBehaviour
	{
		public SpriteMask mask;
		[Range(0f, 5f)]
		public float radius = 3f;

		void Update ()
		{
			mask.transform.localScale = Vector3.one * radius * 2;
		}
	}
}