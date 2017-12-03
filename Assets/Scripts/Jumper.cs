using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class Jumper : MonoBehaviour
	{
		public Rigidbody rb;
		public Vector3 jumpVector = new Vector3(100f, 200f, 0f);
		// public float jumpDuration = 1f;

		public IEnumerator Jump ()
		{
			rb.AddForce(new Vector3(
				transform.forward.normalized.x * jumpVector.x,
				jumpVector.y,
				jumpVector.z)
			);

			yield return null;
			// yield return new WaitForSeconds(jumpDuration);
		}
	}
}
