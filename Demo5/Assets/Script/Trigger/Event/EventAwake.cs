using UnityEngine;
using System.Collections;

public class EventAwake : Event {
	protected override void Awake()
	{
		base.Awake ();
		Raise ();
	}
}
