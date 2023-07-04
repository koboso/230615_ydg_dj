using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{


    private void Update(){
        this.transform.position -= new Vector3(0, 3 * Time.deltaTime, 0);
    }



    public void OnCollisionEnter2D(Collision2D col){

        if(col.collider.gameObject.tag == "Player"){
            GameCore.Instance.EarnItem();
            Destroy(gameObject);
        }


    }


}
