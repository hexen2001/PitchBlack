using UnityEngine;
using System.Collections;
namespace Demo4
{
	/// <summary>
	/// 枪炮武器
	/// </summary>
	public class Gun : MonoBehaviour
	{
		/// <summary>
		/// 冷却时间
		/// </summary>
		public float cooldown = 0.5f;
		/// <summary>
		/// 上次开火时间
		/// </summary>
		private float m_lastFireTime;
		/// <summary>
		/// 子弹Prefab
		/// </summary>
		public Bullet bulletPrefab;
		/// <summary>
		/// 子弹出膛的参照位置和方向
		/// </summary>
		public Transform mark;
		/// <summary>
		/// 武器伤害
		/// </summary>
		public int damagePoint = 1;
		/// <summary>
		/// 当前已进入冷却中(不能开火)
		/// </summary>
		/// <value><c>true</c> if this instance is cooldown; otherwise, <c>false</c>.</value>
		public bool IsCooldownTime
		{
			get{
				return ( m_lastFireTime + cooldown ) > Time.time;
			}
		}
		public Bullet Fire()
		{
			if (bulletPrefab != null)
			{
				var bu = bulletPrefab.gameObject.Create (mark).GetComponent<Bullet> ();
				var tf = bu.transform;
				tf.parent = Manager.main.bulletLayer;
				m_lastFireTime = Time.time;
				bu.damagePoint = damagePoint;

				return bu;
			}
			else
			{
				Debug.LogError ( "bulletPrefab is missing.", gameObject );
			}
			return null;
		}
	}
}