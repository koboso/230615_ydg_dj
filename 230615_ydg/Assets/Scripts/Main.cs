using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour{

    int a;

    int[] arrayNumber = new int[10];

    Enemy[] enemyList = new Enemy[10];


    List<int> listNumber = new List<int>();

    List<Enemy> eList = new List<Enemy>();





    void Start(){
        for(int i =0; i< enemyList.Length; i++){

            Enemy e = new Enemy("elf", i);
            e.GetEnemyInfo();

            eList.Add(e);


        }




    }

}
