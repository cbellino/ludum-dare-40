using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public enum FireflyState
	{
		None,
		Idle,
		MoveToPlayer,
		Following,
		Attracted,
		Dead // :'(
	}

	public class Firefly : MonoBehaviour
	{
		public Rigidbody rb;
		public Collider followCollider;
		public Collider attractCollider;
		public LightEmitter lightEmitter;
		public float moveSpeed = 20f;
		public Vector3 followOffset = new Vector3(1f, 1f, 0f);

		float followDistance = 0.5f;
		FireflyState state;
		float startMoveTimestamp;
		Vector3 moveDestination;
		Vector3 originalPosition;
		bool isMovingIntoPosition;
		Transform followingActor;
		
		void Start ()
		{
			Transition(FireflyState.Idle);
		}

		void Update ()
		{
			switch (state)
			{
				case FireflyState.Attracted:
					// Move the the actor it is attracted to (player, water, etc)
					// Move to target position
					// Set state to Follow
					break;

				case FireflyState.MoveToPlayer:
					MoveToFollowingActorPosition();
					MoveToDestination();
					break;

				case FireflyState.Following:
					Follow();
					break;

				case FireflyState.Idle:
					MoveToRandomIdlePosition();
					if (isMovingIntoPosition) {
						MoveToDestination();
					}
					break;
			}
		}

		void OnChildTriggerEnter (TriggerParam param)
		{
			if (param.source.name == followCollider.name)
			{
				if (param.collider.gameObject.tag == "Player")
				{
					followingActor = param.collider.transform;
					Transition(FireflyState.MoveToPlayer);
				}
			}
		}

		void Transition (FireflyState newState)
		{
			OnExitState(state);
			state = newState;
			OnEnterState(newState);
		}

		void OnEnterState (FireflyState newState)
		{
			// Debug.Log($"OnEnterState: {newState}");

			switch (newState)
			{
				case FireflyState.Idle:
					originalPosition = transform.position;
					followCollider.enabled = true;
					isMovingIntoPosition = false;
					break;

				case FireflyState.MoveToPlayer:
					startMoveTimestamp = Time.time;
					break;

				case FireflyState.Following:
					attractCollider.enabled = true;
					lightEmitter.mask.gameObject.SetActive(false);

					var followingActorLightEmitter = followingActor.GetComponent<LightEmitter>();
					if (followingActorLightEmitter != null)
					{
						followingActorLightEmitter.AddLight(lightEmitter.radius);
					}

					break;
			}
		}

		void OnExitState (FireflyState oldState)
		{
			// Debug.Log($"OnExitState: {oldState}");

			switch (oldState)
			{
				case FireflyState.Idle:
					followCollider.enabled = false;
					break;

				case FireflyState.Following:
					lightEmitter.mask.gameObject.SetActive(true);
					attractCollider.enabled = false;
					break;
			}
		}

		void MoveToRandomIdlePosition ()
		{
			if (!isMovingIntoPosition || transform.position == moveDestination) {
				Vector3 randomPosition = new Vector3(
					originalPosition.x + Random.Range(-0.3f, 0.3f), 
					originalPosition.y + Random.Range(-0.1f, 0.1f),
					originalPosition.z
				);
				moveDestination = randomPosition;
				startMoveTimestamp = Time.time;
				isMovingIntoPosition = true;
				
				// Debug.Log($"Firefly ({name}) moving to {randomPosition}");
			}
		}

		void MoveToFollowingActorPosition ()
		{
			moveDestination = followingActor.position;
			float distanceFromTarget = Vector3.Distance(transform.position, moveDestination);

			if (distanceFromTarget <= followDistance)
			{
				Transition(FireflyState.Following);
				return;
			}
		}

		void Follow ()
		{
			float step = moveSpeed * 10 * Time.deltaTime;
			Vector3 destination = followingActor.position + followOffset;
			transform.position = Vector3.MoveTowards(transform.position, destination, step);
		}

		void MoveToDestination () 
		{
			float journeyLength = Vector3.Distance(transform.position, moveDestination);
			float distanceCovered = (Time.time - startMoveTimestamp) * moveSpeed;
			float fractionJourney = distanceCovered / journeyLength;
			
			transform.position = Vector3.Lerp(transform.position, moveDestination, fractionJourney);
		}
	}
}