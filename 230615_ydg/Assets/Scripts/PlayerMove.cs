using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{

    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        Debug.Log("update Began");

        if (GameCore.Instance.gameStatus != GameCore.GameStatus.Play) return;

        Debug.Log("Update In");

#if UNITY_EDITOR_WIN
        Debug.Log("Update Window");
        WindowPlatform();
#elif PLATFORM_ANDROID
        AndroidPlatform();
        Debug.Log("Update Android");

#endif
    }

    bool isDragging = false;

    Vector3 currentPos;

    private void WindowPlatform(){

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;

            currentPos = this.transform.position - ConvertMousePosition();

        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }



        if (isDragging)
        {
            this.transform.position = ConvertMousePosition() + currentPos;
        }

    }


    private Vector3 ConvertMousePosition(){
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = -Camera.main.transform.position.z;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }


    private void AndroidPlatform(){


       if(Input.touchCount >= 1)
        {

            Debug.Log("Touch IN");

            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    Debug.Log("Began");
                    isDragging = true;
                    currentPos = this.transform.position - ConvertMousePosition();
                    break;
               
                case TouchPhase.Ended:

                    Debug.Log("ended");
                    isDragging = false;
                    break;
            }

            /*
            if (Input.GetMouseButtonDown(0))
            {
                

            }
            else if (Input.GetMouseButtonUp(0))
            {
             
            }

            */


            if (isDragging)
            {
                this.transform.position = ConvertMousePosition() + currentPos;
            }
        }

    }


}


