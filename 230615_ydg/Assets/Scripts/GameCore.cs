using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private GameObject bullet;


    Player playerInfo;

    float delay = 0f;


    // Start is called before the first frame update
    void Start(){
        playerInfo = new Player(5, 10);


    }

    // Update is called once per frame
    void Update(){
        delay += Time.deltaTime;

        if(delay >= 1f){
            delay = 0f;

            GameObject obj = Instantiate(bullet, Vector3.zero, Quaternion.identity, bulletSpawn.transform);
            obj.transform.position = player.transform.position;
            int dmg = playerInfo.Atk;
            obj.GetComponent<Bullet>().InitBullet(dmg);

            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3f);
        }
    }
}
