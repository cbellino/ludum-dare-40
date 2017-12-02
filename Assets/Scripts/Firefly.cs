using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public enum FireflyState
	{
		Idle,
		Attracted,
		Follow,
		Dead // :'(
	}

	public class Firefly : MonoBehaviour
	{
		public Rigidbody rb;
		public float moveSpeed = 20f;
		public Vector3 followOffset = new Vector3(1f, 1f, 0f);
				
		FireflyState state;
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

				case FireflyState.Follow:
					// Follow an actor around
						// Move to target position
						// Loop
					Follow();
					break;

				default: // Idle
					SetIdleDestination();
					MoveToDestination();
					break;
			}
		}

		void OnTriggerEnter(Collider other)
		{	
			if (other.gameObject.tag == "Player")
			{
				followingActor = other.transform;
				SetState(FireflyState.Follow);
			}
		}

		void SetState (FireflyState newState)
		{
			isMoving = false;
			state = newState;
			originalPosition = transform.position;
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

			Debug.Log("MoveToDestination");

			float journeyLength = Vector3.Distance(transform.position, moveDestination);
			float distanceCovered = (Time.time - startMoveTimestamp) * moveSpeed;
			float fractionJourney = distanceCovered / journeyLength;
			
			transform.position = Vector3.Lerp(transform.position, moveDestination, fractionJourney);
		}
	}
}