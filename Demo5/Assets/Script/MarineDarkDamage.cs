using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class OngoingEffectBase : MonoBehaviour
{
	public int stepValue = 1;
	public float intervals = 1;
	private bool Check()
	{
		if( m_nextRaiseTime < Time.time )
		{
			m_nextRaiseTime = Time.time + intervals;
			return true;
		}
		return false;
	}
	protected virtual void Update()
	{
		if( Check() )
		{
			Value = Mathf.Clamp( Value + stepValue, 0, ValueMax );
		}
	}
	protected abstract int Value
	{
		get;
		set;
	}
	protected abstract int ValueMax
	{
		get;
	}
	private float m_nextRaiseTime = 0f;
}
public abstract class OngoingEffect : OngoingEffectBase
{
	public Marine marine
	{
		get
		{
			return self as Marine;
		}
	}
	protected Character self
	{
		get
		{
			if( null == m_self )
			{
				m_self = GetComponent<Character>();
			}
			return m_self;
		}
	}
	private Character m_self = null;
};

public class MarineDarkDamage : OngoingEffect
{
	protected override int Value
	{
		get
		{
			return self.hp;
		}
		set
		{
			self.hp = value;
		}
	}
	protected override int ValueMax
	{
		get
		{
			return self.hpMax;
		}
	}
	protected override void Update()
	{
		if( !marine.lightingOrPowerful )
		{
			base.Update();
		}
	}
}

