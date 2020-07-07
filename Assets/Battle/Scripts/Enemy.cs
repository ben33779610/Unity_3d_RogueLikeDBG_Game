using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
	public EnemyData data;

	

	public GameObject coin;

	private Animator ani;				//動畫

	private NavMeshAgent nav;           //導覽網格代理器

	private float Timer;

	private GameObject[] player;      //抓到所有敵人
	private float[] playerdis;       //取得敵人距離

	//private HpValueManger hpvaluemanger;

	private float hp;

	//摺疊 ctrl+m+o
	//展開 ctrl+m+l 

	private void Start()
	{
		ani = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent>();
		//hpvaluemanger = GetComponentInChildren<HpValueManger>();
		nav.stoppingDistance = data.stopdis;
		nav.speed = data.speed;
		Timer = data.cd-0.5f;
		hp = data.hp;
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

		if (Timer > data.cd)
		{
			Attack();
			Timer = 0;
		}
	}

	/// <summary>
	/// 移動
	/// </summary>
	private void Move()
	{
		if (ani.GetBool("死亡開關")) return;


		player = GameObject.FindGameObjectsWithTag("Player");
		if (player.Length == 0)
		{

		}
		else
		{
			playerdis = new float[player.Length];
			//距離陣列=新的浮點數陣列[數量]
			for (int i = 0; i < player.Length; i++)
			{
				playerdis[i] = Vector3.Distance(transform.position, player[i].transform.position);
				//距離=三為向量(A,B)
			}
			float min = playerdis.Min();
			int index = playerdis.ToList().IndexOf(min);
			Vector3 playerpost = player[index].transform.position;

			// playerpost.y = transform.position.y;
			
			transform.LookAt(playerpost);
			ani.SetBool("跑步開關", true);
			nav.SetDestination(playerpost);

			// print("剩餘距離" + nav.remainingDistance);  跟目的的勝於距離
			if (nav.remainingDistance < nav.stoppingDistance)
			{
				Wait();
			}
			else
			{
				ani.SetBool("跑步開關", true);
			}
		}
	}

	protected virtual void Attack()
	{
		
		ani.SetTrigger("攻擊開關");
	}

	/// <summary>
	/// 受傷
	/// </summary>
	/// <param name="damage">傷害</param>
	public void Hit(float damage)
	{
		if (ani.GetBool("死亡開關")) return;
		hp -= damage;
		//hpvaluemanger.SetHpbar(hp, data.hp);
		//StartCoroutine(hpvaluemanger.ShowText(damage, "-", Color.white));
		if (hp <= 0) Dead();
	}
	/// <summary>
	/// 死亡
	/// </summary>
	private void Dead()
	{
		ani.SetBool("死亡開關", true);
		nav.isStopped = true;
		//CreateCoin();
		Destroy(this);
		Destroy(gameObject, 0.5f);
	}

/*	private void CreateCoin()
	{
		int r =(int)Random.Range(data.coinrange.x, data.coinrange.y);
		for (int i = 0; i < r; i++)
		{
			Instantiate(coin, transform.position + transform.up * 2, transform.rotation);
		}
	}*/
}
