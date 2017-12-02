using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public enum FireflyState
	{
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
		float startMoveTimestamp;
		Vector3 moveDestination;
		Vector3 originalPosition;
		bool isMoving;
		Transform followingActor;
		
		void Start ()
		{
			SetStateIdle();
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

				default: // Idle
					SetIdleDestination();
					MoveToDestination();
					break;
			}
		}

		void SetStateIdle ()
		{
			followCollider.enabled = true;
			lightEmitter.mask.gameObject.SetActive(true);
			originalPosition = transform.position;
			isMoving = false;
			state = FireflyState.Idle;
		}

		void SetStateFollowing (Transform target)
		{
			followCollider.enabled = false;
			lightEmitter.mask.gameObject.SetActive(false);
			followingActor = target;
			state = FireflyState.Following;

			Debug.Log("target" + target.gameObject.name);
			var targerLightEmitter = target.GetComponent<LightEmitter>();
			if (targerLightEmitter != null)
			{
				targerLightEmitter.AddLight(lightEmitter.radius);
			}
		}

		void OnTriggerEnter(Collider other)
		{	
			if (other.gameObject.tag == "Player")
			{
				SetStateFollowing(other.transform);
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