using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor( typeof( StateMachine ) )]
public class StateMachineInspector : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		var names = Names;
		int selectIndex = names.FindIndex( str => str == self.state );
		int result = EditorGUILayout.Popup( "State", selectIndex, names.ToArray() );
		if( result != selectIndex )
		{
			self.state = names[ result ];
			self.Reset();
		}
	}
	private List<string> Names
	{
		get
		{
			List<string> result = new List<string>();
			for( int i = 0; i < self.transform.childCount; ++i )
			{
				result.Add( self.transform.GetChild( i ).name );
			}
			return result;
		}
	}
	private StateMachine self
	{
		get
		{
			return target as StateMachine;
		}
	}
}
