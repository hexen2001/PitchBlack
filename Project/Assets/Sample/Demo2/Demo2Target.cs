using UnityEngine;
using System.Collections;


namespace Demo2
{

public class Demo2Target : MonoBehaviour {

	public NavMeshAgent target;
	void Update () {
			if (target != null)
			{
				target.destination = transform.position;
			}
	
	}
}
}