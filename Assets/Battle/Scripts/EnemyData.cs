using UnityEngine;

//ScriptableObject 可將腳本物件化   存放在場景內  不用掛在物件上


[CreateAssetMenu(fileName = "怪物資料",menuName = "Data/怪物資料")]
public class EnemyData : ScriptableObject
{
	[Header("移動速度"),Range(0,50)]
	public float speed;
	[Header("血量"),Range(100,5000)]
	public float hp;
	[Header("攻擊力"),Range(10,1000)]
	public float atk;
	[Header("冷卻時間"),Range(1,100)]
	public float cd;
	[Header("停止距離"), Range(0.2f, 100)]
	public float stopdis;

	[Header("近距離單位")]
	public float attackY;
	public float attackLength;
	public float attackDelay;

	[Header("遠距離單位子彈距離")]
	public float attackZ;
	[Header("子彈速度"),Range(150,5000)]
	public float bulletspeed;
	[Header("金幣掉落")]
	public Vector2 coinrange;
}
