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
		
		FireflyState state;
		float startMoveTimestamp;
		Vector3 moveDestination;
		Vector3 originalPosition;
		bool isMoving;

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
					// Set state to Loop
					break;

				default: // Idle
					SetIdleDestination();
					MoveToDestination();
					break;
			}
		}

		void SetState (FireflyState newState)
		{
			state = newState;
			originalPosition = transform.position;
		}

		void MoveToDestination () 
		{
			if (!isMoving) { return; }

			float journeyLength = Vector3.Distance(transform.position, moveDestination);
			float distanceCovered = (Time.time - startMoveTimestamp) * moveSpeed;
			float fractionJourney = distanceCovered / journeyLength;
			
			transform.position = Vector3.Lerp(transform.position, moveDestination, fractionJourney);
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
	}
}