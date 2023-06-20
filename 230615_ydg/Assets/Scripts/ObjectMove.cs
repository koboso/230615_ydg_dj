using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour{
    int step = 0;

    void Update(){
        float y = this.transform.position.y;
        float x = this.transform.position.x;

        if(y >= 2f){
            step = 1;
        }
        if(x >= 2f && y >= 2f)
        {
            step = 2;
        }
        if(x >= 2f && y <= -2f)
        {
            step = 3;
        }
        else
        {
            if(step == 3 && x <= -2f)
            {
                step = 0;
            }
        }

        Debug.Log(step);


        switch (step)
        {
            case 0:
                this.transform.position += new Vector3(0, 2 * Time.deltaTime,0);
                break;
            case 1:
                this.transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
                break;
            case 2:
                this.transform.position -= new Vector3(0, 2 * Time.deltaTime, 0);
                break;
            case 3:
                this.transform.position -= new Vector3(2 * Time.deltaTime, 0, 0);
                break;
        }




    }
   
}
