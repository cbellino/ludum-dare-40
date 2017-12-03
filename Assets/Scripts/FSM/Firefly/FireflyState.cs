using UnityEngine;
using System.Collections.Generic;

namespace LD40
{
	public abstract class FireflyState : State
	{
		protected Firefly owner;
		protected float startMoveTimestamp;
		protected Vector3 moveDestination;
		
		protected virtual void Awake ()
		{
			owner = GetComponent<Firefly>();
		}

		protected void MoveToDestination () 
		{
			float journeyLength = Vector3.Distance(transform.position, moveDestination);
			float distanceCovered = (Time.time - startMoveTimestamp) * owner.moveSpeed;
			float fractionJourney = distanceCovered / journeyLength;
			
			transform.position = Vector3.Lerp(transform.position, moveDestination, fractionJourney);
		}
	}
}