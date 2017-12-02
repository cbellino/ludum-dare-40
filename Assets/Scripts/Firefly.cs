using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public enum FireflyState
	{
		None,
		Idle,
		Attracted,
		Following,
		Dead // :'(
	}

	public class Firefly : MonoBehaviour
	{
		public Rigidbody rb;
		public Collider followCollider;
		public LightEmitter lightEmitter;
		public float moveSpeed = 20f;
		public Vector3 followOffset = new Vector3(1f, 1f, 0f);

		FireflyState state;
		FireflyState previousState;
		float startMoveTimestamp;
		Vector3 moveDestination;
		Vector3 originalPosition;
		bool isMoving;
		Transform followingActor;
		
		void Start ()
		{
			SetState(FireflyState.Idle);
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

				case FireflyState.Following:
					Follow();
					break;

				case FireflyState.Idle:
					SetIdleDestination();
					MoveToDestination();
					break;
			}
		}

		void SetState (FireflyState newState)
		{
			OnExitState(state);
			state = newState;
			OnEnterState(newState);
		}

		void OnEnterState (FireflyState newState)
		{
			// Debug.Log($"OnEnterState: {newState}");

			switch (state)
			{
				case FireflyState.Idle:
					followCollider.enabled = true;
					lightEmitter.mask.gameObject.SetActive(true);
					originalPosition = transform.position;
					isMoving = false;
					break;

				case FireflyState.Following:
					followCollider.enabled = false;
					lightEmitter.mask.gameObject.SetActive(false);

					var targerLightEmitter = followingActor.GetComponent<LightEmitter>();
					if (targerLightEmitter != null)
					{
						targerLightEmitter.AddLight(lightEmitter.radius);
					}

					break;
			}
		}

		void OnExitState (FireflyState oldState)
		{
			// Debug.Log($"OnExitState: {oldState}");
		}

		void OnTriggerEnter(Collider other)
		{	
			if (other.gameObject.tag == "Player")
			{
				followingActor = other.transform;
				SetState(FireflyState.Following);
			}
		}

		void Follow ()
		{
			float step = moveSpeed * 10 * Time.deltaTime;
			Vector3 destination = followingActor.position + followOffset;
			transform.position = Vector3.MoveTowards(transform.position, destination, step);
		}

		void SetIdleDestination ()
		{
			if (!isMoving || transform.position == moveDestination) {
				Vector3 randomPosition = new Vector3(
					originalPosition.x + Random.Range(-0.3f, 0.3f), 
					originalPosition.y + Random.Range(-0.1f, 0.1f),
					originalPosition.z
				);
				moveDestination = randomPosition;
				startMoveTimestamp = Time.time;
				isMoving = true;
				
				// Debug.Log($"Firefly ({name}) moving to {randomPosition}");
			}
		}

		void MoveToDestination () 
		{
			if (!isMoving) { return; }

			float journeyLength = Vector3.Distance(transform.position, moveDestination);
			float distanceCovered = (Time.time - startMoveTimestamp) * moveSpeed;
			float fractionJourney = distanceCovered / journeyLength;
			
			transform.position = Vector3.Lerp(transform.position, moveDestination, fractionJourney);
		}
	}
}