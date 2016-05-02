// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class EventBase : FsmStateAction
	{
		public enum EventMode
		{
			Enter,
			Update,
			All,
		}
		public EventMode eventMode = EventMode.All;
		public override void OnEnter()
		{
			switch (eventMode)
			{
			case EventMode.All:
			case EventMode.Enter:
				OnLogic ();
				break;
			}
		}
		public override void OnUpdate()
		{
			switch( eventMode )
			{
			case EventMode.All:
			case EventMode.Update:
				OnLogic ();
				break;
			}
		}
		public virtual void OnLogic()
		{

		}
	}
	public class ActionBase<T> : EventBase
		where T : MonoBehaviour
	{
		private T m_self;
		protected T self
		{
			get
			{
				if (null == m_self)
				{
					m_self = Fsm.GameObject.GetComponent<T> ();
				}
				return m_self;
			}
		}
	}
	[ActionCategory("Pitch Black")]
	public class ActVision : ActionBase<Character>
	{
		public enum VisionEvent
		{
			Enter,
			Exit,
		}
		public VisionEvent mode = VisionEvent.Enter;
		public FsmEvent onEvent;
		public override void OnLogic()
		{
			if (self!=null)
			{
				if (self.target == null)
				{
					if (mode == VisionEvent.Exit)
					{
						Fsm.Event (onEvent);
					}
				}
				else
				{
					if (mode == VisionEvent.Enter)
					{
						Fsm.Event (onEvent);
					}
				}
			}
		}
	}
}