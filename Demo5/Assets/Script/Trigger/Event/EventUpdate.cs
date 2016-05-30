using UnityEngine;
using System.Collections;

public class EventUpdate : Event
{
	void Update()
	{
		Raise();
	}
}
