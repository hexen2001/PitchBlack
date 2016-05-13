using UnityEngine;
using System.Collections;

public class TweenMove : MonoBehaviour {

	public enum Mode
	{
		From,
	}
	public Mode mode = Mode.From;
	public Vector3 amount = Vector3.zero;
	public float time = 1f;
	void Start ()
	{
		switch (mode)
		{
		case Mode.From:
			iTween.MoveFrom (gameObject, transform.position + amount, time);
			break;
		}
	
	}
}
