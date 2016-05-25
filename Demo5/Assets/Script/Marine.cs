using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Marine : Character
{


	#region PowerLight

	public int power = 100;
	public int powerMax = 100;
	public GameObject powerLight;
	public bool powerful
	{
		get
		{
			if( powerLight != null )
			{
				return powerLight.activeSelf;
			}
			else
			{
				return false;
			}
		}
		set
		{
			if( powerLight.activeSelf != value )
			{
				powerLight.SetActive( value );
			}
		}
	}
	void UpdatePowerLight()
	{
		powerful = power > 0;
	}

	#endregion


	#region Lights
	public bool lighting
	{
		get
		{
			return lightCount > 0;
		}
	}
	public bool lightingOrPowerful
	{
		get
		{
			return powerful || lightCount > 0;
		}
	}
	public int lightCount
	{
		get
		{
			return m_lightCount;
		}
		set
		{
			m_lightCount = value;
		}
	}
	[SerializeField]
	private int m_lightCount = 0;
	#endregion


	#region Input
	private void UpdateInput()
	{
		Vector3 dir;
		if( InputUtil.GetWorldInputDir( out dir ) )
		{
			SetMoveDir( dir );
		}
		else
		{
			StopMove();
		}
	}
	#endregion


	protected override void OnDrawGizmos()
	{
		base.OnDrawGizmos();
	}
	protected override void Update()
	{
		UpdateInput();
		UpdatePowerLight();
	}
}
