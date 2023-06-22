using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{

    public GameObject player;


    int step = 0;

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {


        if (step == 1)
        {
            if(player.transform.position.x <= -2f)
            {
                step = 0;
            }
            else
            {
                player.transform.position -= new Vector3(3 * Time.deltaTime, 0, 0);
            }

        }
        
        if(step == 2)
        {
            if(player.transform.position.x >= 2f)
            {
                step = 0;
            }
            else
            {
                player.transform.position += new Vector3(3 * Time.deltaTime, 0, 0);
            }
        }

    }


    public void LeftMove()
    {
        step = 1;
    }


    public void RightMove()
    {
        step = 2;
    }














    int  func(int a, int b)
    {
        return a + b;
    }



























}


