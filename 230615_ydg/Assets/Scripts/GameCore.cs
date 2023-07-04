using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCore : MonoBehaviour{

    public enum GameStatus{
        Ready,
        Init,
        Play,
        GameOver,
    }

    public GameStatus gameStatus;

    private static GameCore instance;

    public static GameCore Instance{
        get{
            return instance;
        }
    }

    [Header("Game UI")]
    [SerializeField] GameObject pannel;
    [SerializeField] Button playBtn;
    [SerializeField] GameObject countdownPannel;
    [SerializeField] TextMeshProUGUI countdownLabel;


    [Header("Game Core object")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private GameObject bullet;
    
    Player playerInfo;

    float delay = 0f;
    private bool isFeverTime = false;

    float fireCondition = 1f;


    float countdown = 3f;


    private void Awake(){
        instance = this;
    }

    // UI Method
    public void PlayGame(){
        CloseGamePannel();
        SetGameStatus(GameStatus.Init);
    }


    private void GameOver(){
        OpenPannel();
        SetGameStatus(GameStatus.GameOver);
    }



    private void OpenPannel(){
        pannel.gameObject.SetActive(true);
    }

    private void CloseGamePannel(){
        pannel.gameObject.SetActive(false);
    }


    public void SetGameStatus(GameStatus status){
        this.gameStatus = status;
    }


    // Core Method
    void Start(){
        playerInfo = new Player(5, 10);
        playBtn.onClick.AddListener(PlayGame);
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

        if(gameStatus == GameStatus.Init){
            ShowCountDownUI();
        }
        else if(gameStatus == GameStatus.Play){

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

    }


    void ShowCountDownUI(){

    }



    IEnumerator FeverTimeUpdate()
    {
        float feverTime = 1.5f;

        while (true){
            if (gameStatus != GameStatus.Play) break;


            feverTime -= Time.deltaTime;
            if (feverTime <= 0){
                StopFeverTime();
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }


}
