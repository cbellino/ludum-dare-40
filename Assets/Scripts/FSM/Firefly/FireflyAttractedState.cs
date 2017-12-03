using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class FireflyAttractedState : FireflyState
	{
		const float followDistance = 0.5f;
		const float speed = 5f;
		bool arrivedAtDestination = false;

		public override void Enter ()
		{
			base.Enter();

			owner.lightEmitter.mask.gameObject.SetActive(true);
			owner.attractCollider.enabled = false;

			StartCoroutine(MoveAndChangeState());
		}

		void Update ()
		{
			// if (arrivedAtDestination) { return; }

			transform.position = Vector3.Lerp(
				transform.position,
				owner.attractedTo.position,
				Time.deltaTime * speed
			);
		}

		IEnumerator MoveAndChangeState ()
		{
			yield return null;

			arrivedAtDestination = true;
			owner.AddLightToFollowingActor(-owner.lightEmitter.radius);
		}
	}
}
