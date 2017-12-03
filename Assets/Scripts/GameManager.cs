using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD40
{
	public class GameManager : MonoBehaviour
	{
		public GameObject player;

		static public GameManager instance
		{
			get { return Instance; }
		}
		static protected GameManager Instance;

		void Start ()
		{
			Instance = this;
		}

		public void OnPlayerDeath ()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}