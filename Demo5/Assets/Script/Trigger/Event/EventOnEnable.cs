using UnityEngine;
using System.Collections;

public class EventOnEnable : Event
{
	protected void OnEnable()
	{
		Raise ();
	}
}
