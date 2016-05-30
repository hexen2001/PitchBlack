using UnityEngine;
using System.Collections;

public class StateLoadScene : MonoBehaviour
{
	public string sceneName;
	void OnEnable ()
	{
		Manager.main.LoadScene (sceneName);
	}
}
