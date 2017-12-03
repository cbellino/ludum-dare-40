using UnityEngine;

namespace LD40
{
	public class FireflyStartFollowingState : FireflyState
	{
		const float followDistance = 0.5f;

		public override void Enter ()
		{
			base.Enter();

			startMoveTimestamp = Time.time;
		}

		public override void Exit ()
		{
			base.Exit();
		}

		void Update ()
		{
			SetMoveDestination();
			MoveToDestination();
		}

		void SetMoveDestination ()
		{
			moveDestination = owner.followingActor.position;

			float distanceFromTarget = Vector3.Distance(transform.position, moveDestination);
			if (distanceFromTarget <= followDistance)
			{
				owner.ChangeState<FireflyFollowState>();
			}
		}
	}
}