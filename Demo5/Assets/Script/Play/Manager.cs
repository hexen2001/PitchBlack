using UnityEngine;
using System.Collections;

public class Manager : Single<Manager>
{
	protected void Awake ()
	{
		Object.DontDestroyOnLoad (gameObject);
	}

	public Game game;
	public Transform buildingLayer;
	public Transform bulletLayer;
	public Marine ctrlPlayer
	{
		get{
			if (null == m_ctrlPalyer)
			{
				m_ctrlPalyer = GameObject.FindObjectOfType<Marine> ();
			}
			return m_ctrlPalyer;
		}
	}
	private Marine m_ctrlPalyer = null;
	public StateMachine uiMngr;

	public void LoadScene (string sceneName)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
	}
}

