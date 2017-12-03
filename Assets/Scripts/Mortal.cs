using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40
{
	public class Mortal : MonoBehaviour
	{
		public void Kill ()
		{
			Debug.Log(name + " died!");

			if (tag == "Player")
			{
				GameManager.instance.OnPlayerDeath();
			}
		}
	}
}