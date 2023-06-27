using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour{

    List<Character> characterList;


    void Start(){

        characterList = new List<Character>();

        PrintAllCharacter();


        CreateCharacter(new Character("ashe", "archer", 100, 30));
        CreateCharacter(new Character("teemo", "thief", 80, 20));
        CreateCharacter(new Character("ezreal", "mage", 70, 100));

        RemoveCharacter(2);
        CreateCharacter(new Character("mesh", "knight", 300, 10));

        PrintAllCharacter();
    }


    public void CreateCharacter(Character c){
        characterList.Add(c);
    }


    public void RemoveCharacter(int index){
        characterList.RemoveAt(index);
    }

    public void PrintAllCharacter(){

        int i = 0; 

        if(characterList.Count == 0)
        {
            Debug.Log("비어있습니다.");
        }
        else
        {
            while (i < characterList.Count)
            {
                characterList[i].GetInfo();
                i++;
            }
        }

        
    }

}
