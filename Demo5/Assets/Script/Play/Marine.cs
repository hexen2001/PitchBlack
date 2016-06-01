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


	public bool lightingOrPowerful
	{
		get
		{
			return powerful || lightCount > 0;
		}
	}


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
		//UpdateInput();
		UpdatePowerLight();
	}
}
