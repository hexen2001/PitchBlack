using UnityEngine;
using System.Collections.Generic;

public class ObjMngr : MonoBehaviour {
	public List<Character> objects = new List<Character> ();
	public void AddObj(Character obj)
	{
		objects.Add (obj);
	}
	public void RemoveObj(Character obj)
	{
		objects.Remove (obj);
	}
}
