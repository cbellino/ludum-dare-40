using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class PlayerMovement : MonoBehaviour
	{
		public Rigidbody rb;
		public float speed = 1f;
		const float threshold = 0.1f;

		void Update ()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");

			if (moveHorizontal != 0f)
			{
				Vector3 velocity = new Vector3(
					moveHorizontal * speed,
					rb.velocity.y,
					rb.velocity.z
				);
				rb.velocity = velocity;
			}
		}
	}
}
