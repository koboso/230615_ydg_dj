using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour{

    private static GameCore instance;

    public static GameCore Instance{
        get{
            return instance;
        }
    }
    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private GameObject bullet;
    
    Player playerInfo;

    float delay = 0f;
    private bool isFeverTime = false;

    float fireCondition = 1f;

    private void Awake(){
        instance = this;
    }


    // Start is called before the first frame update
    void Start(){
        playerInfo = new Player(5, 10);
    }


    public void EarnItem(){
        if (isFeverTime) return;
        isFeverTime = true;
        fireCondition = 0.09f;
        StartCoroutine(FeverTimeUpdate());
    }


    private void StopFeverTime(){
        if (!isFeverTime) return;
        isFeverTime = false;

        fireCondition = 1f;

        StopCoroutine(FeverTimeUpdate());
    }

    // Update is called once per frame
    void Update(){
        delay += Time.deltaTime;


        if(delay >= fireCondition){
            delay = 0f;

            GameObject obj = Instantiate(bullet, Vector3.zero, Quaternion.identity, bulletSpawn.transform);
            obj.transform.position = player.transform.position;
            int dmg = playerInfo.Atk;
            obj.GetComponent<Bullet>().InitBullet(dmg);

            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3f);
        }
    }


    IEnumerator FeverTimeUpdate()
    {
        float feverTime = 1.5f;

        while (true){
            feverTime -= Time.deltaTime;
            if (feverTime <= 0){
                StopFeverTime();
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }


}
