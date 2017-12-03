using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class Player : StateMachine
	{
		public PlayerMovement movement;
		public Jumper jumper;

		void Start ()
		{
			ChangeState<PlayerIdleState>();
		}

		void Update ()
		{
			Debug.DrawRay(transform.position, transform.forward, Color.green);
		}
	}
}
