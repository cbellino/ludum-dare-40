using UnityEngine;

namespace LD40
{
	public class MonsterAttackState : MonsterState
	{
		const float killDistance = 0.5f;

		public override void Enter ()
		{
			base.Enter();

			moveDestination = owner.attackTarget.position;
			startMoveTimestamp = Time.time;
		}

		void Update ()
		{
			MoveToDestination();
			CheckForKill();
		}

		void CheckForKill ()
		{
			float distanceFromTarget = Vector3.Distance(
				transform.position,
				owner.attackTarget.position
			);

			if (distanceFromTarget <= killDistance)
			{
				owner.attackTarget.SendMessage("Kill");
			}
		}
	}
}