using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class Refinery : MonoBehaviour
	{
		public float powerSpeed = 5f;
		void Awake()
		{
			Manager.main.game.refinecyCount++;
		}
		void OnDestroy()
		{
			Manager.main.game.refinecyCount--;
		}
		void Update ()
		{
			Manager.main.game.AddPower( powerSpeed * Time.deltaTime );
		}
	}
}