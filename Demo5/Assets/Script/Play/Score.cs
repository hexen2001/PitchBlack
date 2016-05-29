using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public int power = 0;
	public int metal = 0;
	bool ConsumeResource(int inPower, int inMetal)
	{
		if( power >= inPower && metal >= inMetal )
		{
			power -= inPower;
			metal -= inMetal;
			return true;
		}
		return false;
	}
}
