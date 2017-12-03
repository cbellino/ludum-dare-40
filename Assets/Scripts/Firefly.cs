using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class Firefly : StateMachine
	{
		public Rigidbody rb;
		public Collider followCollider;
		public Collider attractCollider;
		public LightEmitter lightEmitter;
		public float moveSpeed = 20f;
		public Vector3 followOffset = new Vector3(1f, 1f, 0f);
		public Transform followingActor;
		public Transform attractedTo;

		void Start ()
		{
			ChangeState<FireflyIdleState>();
		}

		public void AddLightToFollowingActor(float amount) {
			var followingActorLightEmitter = followingActor.GetComponent<LightEmitter>();
			if (followingActorLightEmitter != null)
			{
				followingActorLightEmitter.AddLight(amount);
			}
		}

		void OnChildTriggerEnter (TriggerParam param)
		{
			if (param.source.name == followCollider.name)
			{
				if (param.collider.gameObject.tag == "Player")
				{
					followingActor = param.collider.transform;
					ChangeState<FireflyStartFollowingState>();
				}
			}
		}
	}
}