using UnityEngine;
using System.Collections;

public class Bullet : TouchBase
{

	public int damagePoint = 0;


	public Character attacker = null;
	
	
	public GameObject hitEffect = null;


	protected override void OnEnter(Character target)
	{
		if( target.Hit( this ) )
		{
			if( hitEffect != null )
			{
				hitEffect.Create( Manager.main.bulletLayer, target.transform );
			}

			Debug.Log ("Bullet Destroy self");
			Destroy( gameObject );
		}
	}


}
