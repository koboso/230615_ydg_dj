using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{

    [SerializeField] private int dmg;


    public void InitBullet(int damage){
        this.dmg = damage;
    }


    private void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 6);
    }


    public void OnCollisionEnter2D(Collision2D col){

        if(col.collider.tag == "Enemy")
        {
            col.collider.gameObject.GetComponent<EnemyObject>().Hit(this.dmg);
            Destroy(this.gameObject);
        }

    }



}
