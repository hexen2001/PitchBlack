using UnityEngine;
using System.Collections;

public class Bullet : TouchBase
{

	public int damagePoint = 0;


	public Character attacker = null;
	
	
	public GameObject hitEffect = null;


	protected override void UpdateLayer()
	{
		gameObject.layer = CampUtil.FireLayer( camp );
	}


	protected override void OnTriggerEnter(Collider target)
	{
		var targetCharacter = target.GetComponent<Character>();
		if( targetCharacter != null )
		{
			if( targetCharacter.Hit( this ) )
			{
				if( hitEffect != null )
				{
					hitEffect.Create( Manager.main.bulletLayer, targetCharacter.transform );
				}

				Destroy( gameObject );
			}
		}
	}


}
