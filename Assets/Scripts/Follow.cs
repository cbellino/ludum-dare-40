using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class Follow : MonoBehaviour
	{
		public Transform target;
		public Vector3 offset = new Vector3(0, 0f, -10f);

		void Update ()
		{
			transform.position = target.position + offset;
		}
	}
}
