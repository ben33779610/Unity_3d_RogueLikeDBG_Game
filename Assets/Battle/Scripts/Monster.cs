using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
	

	public Transform enemypos;         //玩家位置

	public GameObject coin;

	private Animator ani;				//動畫

	private NavMeshAgent nav;           //導覽網格代理器

	private float Timer;

	

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
