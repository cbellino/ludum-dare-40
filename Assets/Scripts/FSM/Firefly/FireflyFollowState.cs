using UnityEngine;

namespace LD40
{
	public class FireflyFollowState : FireflyState
	{
		public override void Enter ()
		{
			base.Enter();

			owner.attractCollider.enabled = true;
			owner.lightEmitter.mask.gameObject.SetActive(false);
			owner.AddLightToFollowingActor(owner.lightEmitter.radius);
		}

		public override void Exit ()
		{
			base.Exit();

			owner.lightEmitter.mask.gameObject.SetActive(true);
			owner.attractCollider.enabled = false;
		}

		void Update ()
		{
			Follow();
		}

		void Follow ()
		{
			float step = owner.moveSpeed * 10 * Time.deltaTime;
			Vector3 destination = owner.followingActor.position + owner.followOffset;
			transform.position = Vector3.MoveTowards(transform.position, destination, step);
		}

		public void AttractedByWater (Water water)
		{
			owner.attractedTo = water.transform;
			owner.ChangeState<FireflyAttractedState>();
		}
	}
}