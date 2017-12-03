using UnityEngine;

namespace LD40
{
	public class FireflyAttractedState : FireflyState
	{
		public override void Enter ()
		{
			base.Enter();

			startMoveTimestamp = Time.time;
			owner.lightEmitter.mask.gameObject.SetActive(true);
			owner.followCollider.enabled = false;
			owner.attractCollider.enabled = false;
			owner.AddLightToFollowingActor(-owner.lightEmitter.radius);
		}

		public override void Exit ()
		{
			base.Exit();
		}

		void Update ()
		{
			MoveToAttracted();
			MoveToDestination();
		}
		
		void MoveToAttracted()
		{
			moveDestination = owner.attractedTo.position;
		}
	}
}