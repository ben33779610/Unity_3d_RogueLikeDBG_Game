using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{

<<<<<<< Updated upstream
	public Transform enemypos;         //玩家位置
=======

    public EnemyData data;

    public Transform enemypos;         //敵人位置
>>>>>>> Stashed changes

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
        nav.stoppingDistance = data.stopdis;
        nav.speed = data.speed;
        Timer = data.cd - 0.5f;
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


        //抓出所有敵人
        enemy = FindObjectsOfType<Enemy>();
        if (enemy.Length == 0)
        {

        }
        else
        {
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
            Vector3 enemypost = enemy[index].transform.position;
            enemypost.y = transform.position.y;
            transform.LookAt(enemypost);

            enemypos.position = enemypost;
            ani.SetBool("跑步開關", true);
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
	}

	protected virtual void Attack()
	{
<<<<<<< Updated upstream
		
		ani.SetTrigger("攻擊開關");
=======
		if (Timer < data.cd)
		{
			Timer += Time.deltaTime;
		}
		else
		{
            ani.SetTrigger("攻擊開關");
		}
>>>>>>> Stashed changes
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
