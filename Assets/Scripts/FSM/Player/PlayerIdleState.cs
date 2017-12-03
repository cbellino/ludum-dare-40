using UnityEngine;

namespace LD40
{
	public class PlayerIdleState : PlayerState
	{
		public override void Enter ()
		{
			base.Enter();
		}

		public override void Exit ()
		{
			base.Exit();
		}

		void Update ()
		{
			// float moveHorizontal = Input.GetAxis("Horizontal");
			bool jumpPressed = Input.GetButtonDown("Jump");
			if (jumpPressed)
			{
				owner.ChangeState<PlayerJumpingState>();
			}
		}
	}
}