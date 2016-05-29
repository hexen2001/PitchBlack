using UnityEngine;
using System.Collections.Generic;


public class StateMachine : MonoBehaviour
{
	[ContextMenu( "Main" )]
	protected void ToMain()
	{
		state = "Main";
	}
	[ContextMenu( "WorldMap" )]
	protected void ToWorldMap()
	{
		state = "WorldMap";
	}
	[ContextMenu( "Play" )]
	protected void ToPlay()
	{
		state = "Play";
	}


	protected void Awake()
	{
		Reset();
	}

	public void Reset()
	{
		for( int i = 0; i < transform.childCount; ++i )
		{
			var go = transform.GetChild( i ).gameObject;
			go.SetActive( go == m_state );
		}
	}
	[SerializeField]
	private GameObject m_state = null;
	public string state
	{
		get
		{
			if( m_state != null )
			{
				return m_state.name;
			}
			return string.Empty;
		}
		set
		{

			if( m_state != null )
			{
				if( m_state.name == value )
				{
					return;
				}
			}
			if( m_state != null )
			{
				m_state.SetActive( false );
				m_state = null;
			}
			var tf = transform.FindChild( value );
			if( tf != null )
			{
				m_state = tf.gameObject;
				m_state.SetActive( true );
			}
		}
	}
}
