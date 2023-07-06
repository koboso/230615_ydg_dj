using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCore : MonoBehaviour
{

    public enum GameStatus
    {
        Ready,
        Init,
        Play,
        GameOver,
    }

    public GameStatus gameStatus;

    private static GameCore instance;

    public static GameCore Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("Game UI")]
    [SerializeField] GameObject pannel;
    [SerializeField] Button playBtn;
    [SerializeField] GameObject countdownPannel;
    [SerializeField] TextMeshProUGUI countdownLabel;
    [SerializeField] TextMeshProUGUI scoreLabel;
    [SerializeField] GameObject[] hpObject;


    [SerializeField] GameObject ingameBestScorePannel;
    [SerializeField] GameObject ingameScorePannel;

    [SerializeField] TextMeshProUGUI bestScoreLabel;
    [SerializeField] TextMeshProUGUI ingameBestScoreLabel;


    [Header("Game Core object")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject hitEffectExplosion;


    private int score = 0;

    private int bestScoreValue = 0;

    float delay = 0f;
    private bool isFeverTime = false;
    float fireCondition = 1f;

    Player playerInfo;

    float countdown = 3f;

    private int wave = 0;

    private int[] waveEnemey = { 10, 20, 30, 50, 100, 300, 400, 500, 600, 800, 1000, 1200, 1500 };

    public int Wave
    {
        get
        {
            return this.wave;
        }
    }

    public int GetWaveEnemey
    {
        get
        {
            return this.waveEnemey[wave];
        }
    }

    public void IncreaseWave()
    {

        Debug.Log($"Increase Wave ==> {wave}");
        this.wave += 1;
    }


    private void Awake()
    {
        instance = this;
    }

    // UI Method
    public void PlayGame()
    {
        CloseGamePannel();
        SetGameStatus(GameStatus.Init);
    }


    private void GameOver()
    {
        wave = 0;

        if(score > bestScoreValue){

            Debug.Log("Connect");
            SaveData();
        }


        score = 0;

        OpenPannel();
        SetGameStatus(GameStatus.GameOver);

        ingameBestScorePannel.gameObject.SetActive(false);
        ingameScorePannel.gameObject.SetActive(false);

        for(int i = 0; i < hpObject.Length; i++){
            if (hpObject[i].gameObject.activeSelf) hpObject[i].SetActive(false);
        }
    }



    private void OpenPannel()
    {
        pannel.gameObject.SetActive(true);
    }

    private void CloseGamePannel()
    {
        pannel.gameObject.SetActive(false);
    }


    public void SetGameStatus(GameStatus status)
    {
        this.gameStatus = status;
    }

    public GameObject BulletSpawn
    {
        get
        {
            return this.bulletSpawn;
        }
    }


    // Core Method
    void Start()
    {
        playerInfo = new Player(3, 10);
        playBtn.onClick.AddListener(PlayGame);
        scoreLabel.gameObject.SetActive(false);


        if (ingameScorePannel.gameObject.activeSelf) ingameScorePannel.gameObject.SetActive(false);
        if (ingameBestScorePannel.gameObject.activeSelf) ingameBestScorePannel.gameObject.SetActive(false);

        for (int i = 0; i < hpObject.Length; i++)
        {
            hpObject[i].gameObject.SetActive(false);
        }

        bestScoreLabel.text = $"Best : {LoadData()}";

    }


    public void EarnItem()
    {
        if (isFeverTime) return;
        isFeverTime = true;
        fireCondition = 0.09f;
        StartCoroutine(FeverTimeUpdate());
    }



    private void StopFeverTime()
    {
        if (!isFeverTime) return;
        isFeverTime = false;
        fireCondition = 1f;
        StopCoroutine(FeverTimeUpdate());
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMove();

        if (gameStatus == GameStatus.Init)
        {
            if (ingameScorePannel.gameObject.activeSelf) ingameScorePannel.gameObject.SetActive(false);
            if (ingameBestScorePannel.gameObject.activeSelf) ingameBestScorePannel.gameObject.SetActive(false);
            InitScore();
            InitPlayer();
            ShowCountDownUI();
        }
        else if (gameStatus == GameStatus.Play)
        {

            ShowBestScore();

            delay += Time.deltaTime;
            if (delay >= fireCondition)
            {
                delay = 0f;

                GameObject obj = Instantiate(bullet, Vector3.zero, Quaternion.identity, bulletSpawn.transform);
                obj.transform.position = player.transform.position;
                int dmg = playerInfo.Atk;
                obj.GetComponent<Bullet>().InitBullet(dmg);

                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10f);
            }
        }
    }

    private void PlayerMove()
    {
       

    }


    void ShowBestScore(){
        if(score >= bestScoreValue)
        {
            if (!ingameBestScoreLabel.gameObject.activeSelf) ingameBestScoreLabel.gameObject.SetActive(true);
            ingameBestScoreLabel.text = $"Best : {score}";
        }
        else
        {
            if (ingameBestScoreLabel.gameObject.activeSelf) ingameBestScoreLabel.gameObject.SetActive(false);
        }
    }


    void InitPlayer()
    {
        playerInfo.Init(3);
    }

    // hp 초기화 해주는 곳.
    void InitHpObject()
    {
        for (int i = 0; i < 3; i++)
        {
            hpObject[i].gameObject.SetActive(true);
        }
    }


    void ShowCountDownUI()
    {
        if (!countdownPannel.gameObject.activeSelf) countdownPannel.gameObject.SetActive(true);


        countdown -= Time.deltaTime;
        int number = (int)countdown + 1;
        countdownLabel.text = number.ToString();

        if (countdown <= 0f)
        {
            countdown = 3f;
            countdownPannel.gameObject.SetActive(false);
            SetGameStatus(GameStatus.Play);
            InitHpObject();

            bestScoreValue = LoadData();

            if (!ingameScorePannel.gameObject.activeSelf) ingameScorePannel.gameObject.SetActive(true);
            if (!ingameBestScorePannel.gameObject.activeSelf) ingameBestScorePannel.gameObject.SetActive(true);

        }

    }

    public void IncreaseScore(int v = 10)
    {
        score += v;
        scoreLabel.text = $"Score : {score}";
    }

    private void InitScore(){
        score = 0;
        bestScoreLabel.text = $"Best : {LoadData()}";
    }



    IEnumerator FeverTimeUpdate()
    {
        float feverTime = 1.5f;

        while (true)
        {
            if (gameStatus != GameStatus.Play) break;


            feverTime -= Time.deltaTime;
            if (feverTime <= 0)
            {
                StopFeverTime();
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void HitDamage()
    {
        // Import


         GameObject hitEffect = Instantiate(hitEffectExplosion, Vector3.zero, Quaternion.identity, bulletSpawn.transform);
        hitEffect.transform.position = player.transform.position;



        playerInfo.HitDamage();

        int hpIndex = playerInfo.Hp - 1;

        if (hpIndex == -1)
        {
            GameOver();
        }
        else
        {
            hpObject[hpIndex].gameObject.SetActive(false);
        }

    }



    private void SaveData()
    {
        PlayerPrefs.SetInt("_Score", score);
        PlayerPrefs.Save();
    }


    private int LoadData()
    {
        return PlayerPrefs.GetInt("_Score", 0);
    }

}
