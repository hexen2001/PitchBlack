using UnityEngine;
using System.Collections;

public class Manager : Single<Manager>
{
	protected void Awake ()
	{
		Object.DontDestroyOnLoad (gameObject);
	}

	public Score score;
	public StateMachine gameState;
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

	public void LoadScene (string sceneName)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
	}
}

