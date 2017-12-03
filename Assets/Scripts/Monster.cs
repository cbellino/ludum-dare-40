using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class Monster : StateMachine 
	{
		private void Start ()
		{
			ChangeState<MonsterIdleState>();
		}
	}
}

