using UnityEngine;
using System.Collections;

public class StateLoadUI : MonoBehaviour
{
	public string uiView;
	protected void OnEnable()
	{
		Manager.main.uiMngr.state = uiView;
	}
}
