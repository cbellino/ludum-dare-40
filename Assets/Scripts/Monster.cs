using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class Monster : StateMachine 
	{
		public Collider attackCollider;
		public float moveSpeed = 1f;
		public Transform attackTarget;

		private void Start ()
		{
			ChangeState<MonsterIdleState>();
		}

		void OnChildTriggerEnter (TriggerParam param)
		{
			if (IsPlayer(param) && IsAttackCollider(param))
			{
				attackTarget = param.collider.transform;
				ChangeState<MonsterAttackState>();
			}
		}

		bool IsPlayer (TriggerParam param)
		{
			return param.collider.tag == "Player";
		}

		bool IsAttackCollider (TriggerParam param)
		{
			return param.source.name == attackCollider.name;
		}
	}
}

