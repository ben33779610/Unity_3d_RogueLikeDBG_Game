using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float hp;
	private Animator ani;

    private void Start()
    {
		ani = GetComponent<Animator>();
    }

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
		
	}
}
