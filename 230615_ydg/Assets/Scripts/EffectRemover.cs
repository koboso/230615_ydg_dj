using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRemover : MonoBehaviour{
    // Start is called before the first frame update

    float t = 0f;
    void Update(){
        t += Time.deltaTime;
        if(t >= 1.5f){
            Destroy(this.gameObject);
        }
    }
}
