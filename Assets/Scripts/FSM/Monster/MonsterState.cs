using UnityEngine;
using System.Collections.Generic;

namespace LD40
{
	public abstract class MonsterState : State
	{
		protected Monster owner;

		protected virtual void Awake ()
		{
			owner = GetComponent<Monster>();
		}
	}
}