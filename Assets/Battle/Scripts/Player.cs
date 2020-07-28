using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public Transform playertf;
	public Animator playerani;

	public float hp;
	public GameObject DEADimg;

	[Header("牌組" + "內容")]
	public Transform deckcontent;

	private Animator ani;



    private void Start()
    {
		ani = GetComponent<Animator>();
    }

    private void Update()
    {
		if (DeckManager.instance.Startbattle)
			Move();
		if(!GameManager.instance.checkwin)
			GameManager.instance.CheckWin();
	}


	public void Move()
	{
		if (playertf.position.z < 350)
		{
			playerani.SetBool("移動開關", true);
			playertf.Translate(Vector3.forward * Time.deltaTime * 50);

		}
		else
		{
			playerani.SetBool("移動開關", false);
			DeckManager.instance.deckcontent = deckcontent;
			DeckManager.instance.BattleDeckInit();
			DeckManager.instance.StartBattle();
			DeckManager.instance.Startbattle = false;
		}

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
		DEADimg.SetActive(true);
	}
}
