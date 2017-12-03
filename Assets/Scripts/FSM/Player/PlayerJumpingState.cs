using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class PlayerJumpingState : PlayerState
	{
		public override void Enter ()
		{
			base.Enter();

			// owner.movement.enabled = false;

			StartCoroutine(Jump());
		}

		public override void Exit ()
		{
			base.Exit();

			// owner.movement.enabled = true;
		}

		IEnumerator Jump ()
		{
			yield return owner.jumper.Jump();

			owner.ChangeState<PlayerIdleState>();
		}
	}
}
