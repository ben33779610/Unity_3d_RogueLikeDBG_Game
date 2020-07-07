using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform playertf;
    public Animator playerani;


    private void Start()
    {
        
    }

    private void Update()
    {
        if(DeckManager.instance.Startbattle)
            Move();
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
        }
        
    }
}
