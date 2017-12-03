using UnityEngine;

namespace LD40
{
	public class FireflyIdleState : FireflyState
	{
		Vector3 originalPosition;

		public override void Enter ()
		{
			base.Enter();

			originalPosition = transform.position;
			moveDestination = originalPosition;
			owner.attractCollider.enabled = false;
		}

		public override void Exit ()
		{
			base.Exit();

			owner.followCollider.enabled = false;
		}

		void Update ()
		{
			ChooseRandomDestination();
			MoveToDestination();
		}
		
		void ChooseRandomDestination ()
		{
			if (transform.position == moveDestination) {
				Vector3 randomPosition = new Vector3(
					originalPosition.x + Random.Range(-0.3f, 0.3f), 
					originalPosition.y + Random.Range(-0.1f, 0.1f),
					originalPosition.z
				);
				moveDestination = randomPosition;
				startMoveTimestamp = Time.time;
			}
		}
	}
}