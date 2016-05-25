using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody ) )]
[RequireComponent( typeof( Collider ) )]
public abstract class TouchBase : MonoBehaviour
{
	#region Camp and Layer

	public virtual Camp camp
	{
		get
		{
			return m_camp;
		}
		set
		{
			if( m_camp != value )
			{
				m_camp = value;
				UpdateLayer();
			}
		}
	}

	[SerializeField]
	private Camp m_camp = Camp.Human;

	protected virtual void UpdateLayer()
	{
		gameObject.layer = CampUtil.SelfLayer( camp );
	}

	#endregion

	#region Event

	protected void OnTriggerEnter(Collider collider)
	{
		var target = collider.gameObject.GetComponent<Character>();
		if( target != null )
		{
			OnEnter( target );
		}
	}
	protected void OnTriggerExit(Collider collider)
	{
		var target = collider.gameObject.GetComponent<Character>();
		if( target != null )
		{
			OnExit( target );
		}
	}
	protected virtual void OnEnter(Character target)
	{
	}
	protected virtual void OnExit(Character target)
	{
	}



	protected virtual void Awake()
	{
		UpdateLayer();
	}


	#endregion
}
