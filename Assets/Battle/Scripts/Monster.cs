using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
	

	public Transform enemypos;         //敵人位置

	public GameObject coin;

	private Animator ani;				//動畫

	private NavMeshAgent nav;           //導覽網格代理器

	private float Timer;
	private Enemy[] enemy;      //抓到所有敵人
	private float[] enemydis;       //取得敵人距離


	private float hp;

	//摺疊 ctrl+m+o
	//展開 ctrl+m+l 

	private void Start()
	{
		ani = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent>();
		
		enemypos = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
		
		
		
		
	}
	private void Update()
	{
		Move();
	}

	/// <summary>
	/// 等待
	/// </summary>
	private void Wait()
	{
		ani.SetBool("跑步開關", false);
		Timer += Time.deltaTime;


	}

	/// <summary>
	/// 移動
	/// </summary>
	private void Move()
	{
		if (ani.GetBool("死亡開關")) return;
		Vector3 postarget = enemypos.position;
		postarget.y = transform.position.y;
		transform.LookAt(postarget);
		ani.SetBool("跑步開關",true);
		nav.SetDestination(enemypos.position);

		//print("剩餘距離" + nav.remainingDistance);  跟目的的勝於距離
		if (nav.remainingDistance < nav.stoppingDistance)
		{
			Wait();
		}
		else
		{
			ani.SetBool("跑步開關", true);
		}
	}

	protected virtual void Attack()
	{
		if (Timer < data.atkcd)
		{
			Timer += Time.deltaTime;
		}
		else
		{
			//抓出所有敵人
			enemy = FindObjectsOfType<Enemy>();
			ani.SetTrigger("攻擊開關");
			//所有敵人的距離
			enemydis = new float[enemy.Length];
			//距離陣列=新的浮點數陣列[數量]
			for (int i = 0; i < enemy.Length; i++)
			{
				enemydis[i] = Vector3.Distance(transform.position, enemy[i].transform.position);
				//距離=三為向量(A,B)
			}
			float min = enemydis.Min();
			int index = enemydis.ToList().IndexOf(min);
			Vector3 enemypos = enemy[index].transform.position;
			enemypos.y = transform.position.y;
			transform.LookAt(enemypos);
		}
	}

	/// <summary>
	/// 受傷
	/// </summary>
	/// <param name="damage">傷害</param>
	public void Hit(float damage)
	{
		if (ani.GetBool("死亡開關")) return;
		hp -= damage;
		
		
		if (hp <= 0) Dead();
	}
	/// <summary>
	/// 死亡
	/// </summary>
	private void Dead()
	{
		ani.SetBool("死亡開關", true);
		nav.isStopped = true;
		CreateCoin();
		Destroy(this);
		Destroy(gameObject, 0.5f);
	}

	private void CreateCoin()
	{
		
	
	}
}
