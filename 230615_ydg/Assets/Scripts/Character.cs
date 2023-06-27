using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character{

    private string name;
    private string job;
    private int hp;
    private int atk;


    public Character(string name, string job, int hp, int atk)
    {
        this.name = name;
        this.job = job;
        this.hp = hp;
        this.atk = atk;
    }


    public string Name{
        get{
            return this.name;
        }
    }

    public string Job
    {
        get
        {
            return this.job;
        }
    }

    public int Hp
    {
        get
        {
            return this.hp;
        }
    }
        
    public int Atk
    {
        get
        {
            return this.atk;
        }
    }

    public void GetInfo(){
        Debug.Log($"name {this.name}, job {job} , hp {hp}, atk {atk}");
    }



}
