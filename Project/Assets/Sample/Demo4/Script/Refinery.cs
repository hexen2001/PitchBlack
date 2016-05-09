using UnityEngine;
using System.Collections;

namespace Demo4
{
	public class Refinery : MonoBehaviour
	{
		public float powerSpeed = 5f;
		void Awake()
		{
			Game.AddRefinery(this);
		}
		void OnDestroy()
		{
			Game.RemoveRefinery( this );
		}
		private void AddPower(float power)
		{
			Manager.main.game.AddPower( power );
		}
		void Update ()
		{
			AddPower( powerSpeed * Time.deltaTime );
		}
	}
}