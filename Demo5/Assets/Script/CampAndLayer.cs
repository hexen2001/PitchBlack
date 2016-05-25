

public enum Camp
{
	Human,
	Monster,
	Trigger,
}


public enum Layer : int
{
	Force1 = 8,
	Force1Fire = 9,
	Force2 = 12,
	Force2Fire = 13,
}


public static class CampUtil
{
	public static int SelfLayer(Camp camp)
	{
		switch( camp )
		{
			case Camp.Human:
				return (int)Layer.Force1;
			case Camp.Trigger:
				return (int)Layer.Force2Fire;
			case Camp.Monster:
			default:
				return (int)Layer.Force2;
		}
	}
	public static int FireLayer(Camp camp)
	{
		switch( camp )
		{
			case Camp.Human:
				return (int)Layer.Force1Fire;
			case Camp.Trigger:
				return (int)Layer.Force2Fire;
			case Camp.Monster:
			default:
				return (int)Layer.Force2Fire;
		}
	}
}
