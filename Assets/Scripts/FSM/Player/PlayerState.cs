using UnityEngine;
using System.Collections.Generic;

namespace LD40
{
	public abstract class PlayerState : State
	{
		protected Player owner;

		protected virtual void Awake ()
		{
			owner = GetComponent<Player>();
		}
	}
}