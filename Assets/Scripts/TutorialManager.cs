using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject starship;
    public StarshipController st;
    private int popUpIndex = 0;
    // Update is called once per frame

    void Update(){
    
    for (int i = 0; i < popUps.Length; i++){
        popUps[i].SetActive(i == popUpIndex);
    }
    // print(popUpIndex);

    if (popUpIndex == 0){
        if (starship.transform.position.y > 500){
            popUpIndex++;
        }
    } else if (popUpIndex == 1){
        if (Input.GetAxis("Horizontal") != 0 ){
            popUpIndex++;
        }
    } else if (popUpIndex == 2){
        if (Input.GetKeyDown(KeyCode.Return)){
            popUpIndex++;
        }
    } else if (popUpIndex == 3){
        if (st.landed){
             popUpIndex++;
        }
    } else if (popUpIndex == 4){
        if (Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene(1);
        }
    }

    }
}
