using UnityEngine;
using System.Collections;

public class GameCtrl : MonoBehaviour
{
	public enum StateId
	{
		None,
		Start,
		SelectMap,
		Play,
	}

	[System.Serializable]
	public class State
	{
		public StateId stateId;
		public GameObject uiPrefab;
		public string sceneName;

		public void Open ()
		{
		}

		public void Close ()
		{
		}
	}

	public State[] states;
	public StateId stateId = StateId.Start;
	private StateId m_stateId;

	private State GetState (StateId id)
	{
		foreach (var obj in states)
		{
			if (obj.stateId == id)
			{
				return obj;
			}
		}
		return null;
	}

	void Awake()
	{
		Object.DontDestroyOnLoad (gameObject);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Start");
	}

	void Update ()
	{
		if (m_stateId != stateId)
		{
			GetState (m_stateId).Close ();
			m_stateId = stateId;
			GetState (m_stateId).Open ();
		}
	}
}
