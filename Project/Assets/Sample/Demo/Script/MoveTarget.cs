using UnityEngine;
using System.Collections;

public class MoveTarget : MoveDir {
	public Transform target;
	protected override void Update () {
		dir = (target.position - transform.position ).normalized;
		base.Update ();
	}
}
