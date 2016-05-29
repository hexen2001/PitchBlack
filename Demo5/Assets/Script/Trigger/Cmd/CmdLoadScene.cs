using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CmdLoadScene : Cmd
{

	public string sceneName;

	protected override void OnDo ()
	{
		if (SceneManager.GetActiveScene ().name != sceneName)
		{
			SceneManager.LoadScene (sceneName);
			SceneManager.SetActiveScene( SceneManager.GetSceneByName (sceneName) );
		}
	}
}
