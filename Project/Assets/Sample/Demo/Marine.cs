using UnityEngine;
using System.Collections;

public class Marine : MonoBehaviour {
	public NavMeshAgent nav;
	public void SetDest(Vector3 dest)
	{
		nav.SetDestination (dest);
	}
}
