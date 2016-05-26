using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody ) )]
[RequireComponent( typeof( SphereCollider ) )]
public abstract class TouchBase : MonoBehaviour
{

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
	}


	#endregion

}
