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
        Move();
    }

    public void Move()
    {
        if(playertf.position.z < 275)
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
