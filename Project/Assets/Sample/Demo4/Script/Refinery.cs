using UnityEngine;
using System.Collections;

namespace Demo4
{
	public enum ResourceType
	{
		Power,
		Metal,
	}
	public class Refinery : MonoBehaviour
	{
		public ResourceType resourceType = ResourceType.Power;
		public float speed = 1f;
		void Awake()
		{
			Game.AddRefinery(this);
		}
		void OnDestroy()
		{
			Game.RemoveRefinery( this );
		}
		void Update ()
		{
			Manager.main.game.AddResource( resourceType, speed * Time.deltaTime );
		}
	}
}