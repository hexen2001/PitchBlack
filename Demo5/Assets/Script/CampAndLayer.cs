

public enum Camp
{
	Human,
	Monster,
	Trigger,
}


public enum Layer : int
{
	Human = 8,
	HitMonster = 9,
	Dialog = 10,
	HitDialog = 11,
	Monster = 12,
	HitHuman = 13,
}


public static class CampUtil
{
	public static int SelfLayer(Camp camp)
	{
		switch( camp )
		{
			case Camp.Human:
				return (int)Layer.Human;
			case Camp.Trigger:
				return (int)Layer.HitHuman;
			case Camp.Monster:
			default:
				return (int)Layer.Monster;
		}
	}
	public static int FireLayer(Camp camp)
	{
		switch( camp )
		{
			case Camp.Human:
				return (int)Layer.HitMonster;
			case Camp.Trigger:
				return (int)Layer.HitHuman;
			case Camp.Monster:
			default:
				return (int)Layer.HitHuman;
		}
	}
}
