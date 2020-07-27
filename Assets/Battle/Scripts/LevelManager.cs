using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform playertf;
    public Animator playerani;
    public GameObject Rewardplace;
    public GameObject Rewardcardimg;
    public Transform Rewardcardimg2;
    public GameObject cardobject;
    public GameObject[] Rewardcards = new GameObject[3];

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if(DeckManager.instance.Startbattle)
            Move();
        CheckWin();
    }

    public void Move()
    {
        if(playertf.position.z < 350)
        {
            playerani.SetBool("移動開關", true);
            playertf.Translate(Vector3.forward * Time.deltaTime*50);
            
        }
        else
        {
            playerani.SetBool("移動開關", false);
            DeckManager.instance.BattleDeckInit();
            DeckManager.instance.StartBattle();
            DeckManager.instance.Startbattle = false;
        }
        
    }

    public void CheckWin()
    {
        if (GameObject.FindWithTag("Enemy") == null)
        {
            print("贏了");
            Rewardplace.SetActive(true);
        }
            
        
    }

    public void ShowRewardCard()
    {
        Rewardcardimg.SetActive(true);
        int num;
        int cardlen = GetCard.instance.cards.Length;
        for (int i = 0; i < 3; i++)
        {
            num = Random.Range(1, cardlen);
            CardData card = GetCard.instance.cards[num-1];
            Transform temp =  Instantiate(cardobject, Rewardcardimg2).transform;
            
            temp.Find("名稱").GetComponent<Text>().text = card.name.ToString();
            temp.Find("描述").GetComponent<Text>().text = card.description.ToString();
            temp.Find("消耗").GetComponent<Text>().text = card.cost.ToString();
            temp.Find("血量").GetComponent<Text>().text = card.hp.ToString();
            temp.Find("攻擊").GetComponent<Text>().text = card.attack.ToString();
            temp.Find("卡圖").GetComponent<Image>().sprite = Resources.Load<Sprite>("picture/" + card.file);
            temp.gameObject.AddComponent<Button>().onClick.AddListener(delegate { DeckManager.instance.AddCard(card.index); });
            Rewardcards[i] = temp.gameObject;
        }
    }
}
