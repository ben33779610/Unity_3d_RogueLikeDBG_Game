using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject endingplace;
    public Transform Rewardchoose;
    public GameObject Rewardcardimg;
    public Transform Rewardcardimg2;
    public GameObject cardobject;
    public GameObject RewardObject;
    public GameObject[] Rewardcards = new GameObject[3];
    public bool checkwin;
    public bool one = true;

    public GameObject reward;

    private void Start()
    {
        instance = this;
        
        
        
    }

    private void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.A))
        {
            GameManager.instance.checkwin = true;
        }*/
    }


    public void CheckWin()
    {
        
        if (GameObject.FindWithTag("Enemy") == null|| checkwin)
        {
            print("贏了");
            endingplace.SetActive(true);
            checkwin = true;
            if (checkwin&& one)
            {
                one = false;
                reward = Instantiate(RewardObject, Rewardchoose);
                reward.GetComponent<Button>().onClick.AddListener(ShowRewardCard);
                print("u can choose");
            }
        }
            
        
    }

    public void ShowRewardCard()
    {
        print("有近來喔");
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


    public void LoadLevel()
    {
        SceneManager.LoadScene("Map");
        
    }

}
