using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class Rotate : MonoBehaviour
	{
		public Rigidbody rb;

		void Update ()
		{
			if (rb.velocity.x < 0f) {
				transform.rotation = Quaternion.LookRotation(Vector3.left);
			} else if (rb.velocity.x > 0f)  {
				transform.rotation = Quaternion.LookRotation(Vector3.right);
			}
		}
	}
}
