using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody ) )]
[RequireComponent( typeof( SphereCollider ) )]
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


	#region Unity Event


	protected void Reset()
	{
		GetComponent<Rigidbody>().useGravity = false;
		GetComponent<Collider>().isTrigger = true;
	}


	protected virtual void OnTriggerEnter(Collider collider)
	{
	}



	protected virtual void OnTriggerExit(Collider collider)
	{
	}



	protected virtual void Awake()
	{
		UpdateLayer();
	}


	#endregion

}
