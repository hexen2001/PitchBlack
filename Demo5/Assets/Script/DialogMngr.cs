using UnityEngine;
using System.Collections.Generic;

public class DialogMngr : MonoBehaviour
{
	public List<DialogTrigger> dialogs
		= new List<DialogTrigger>();


	public void Add(DialogTrigger trigger)
	{
		dialogs.Add( trigger );
	}


	public void Remove(DialogTrigger trigger)
	{
		dialogs.Remove( trigger );
	}


	protected void Update()
	{
		dialogs.RemoveAll( obj => obj == null );
		
		var selfPosition = Manager.main.ctrlPlayer.transform.position;
		dialogs.Sort((DialogTrigger a, DialogTrigger b)=>{
			float distanceA = (a.transform.position - selfPosition).magnitude;
			float distanceB = (b.transform.position - selfPosition).magnitude;
			return distanceA < distanceB ? -1 : 1;
		});
	}


}
