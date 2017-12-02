using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class PlayerMovement : MonoBehaviour
	{
		public Rigidbody rb;
		public float speed = 1f;

		void Update ()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");

			Vector3 moveForce = new Vector3(moveHorizontal, 0f, 0f);
			rb.velocity += moveForce * Mathf.Max(2f, speed);
		}
	}
}