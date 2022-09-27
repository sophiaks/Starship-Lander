using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    // Update is called once per frame
    
    void Update(){

    for (int i = 0; i < popUps.Length; i++){
        if(i == popUpIndex){
            popUps[popUpIndex].SetActive(true);
        }else{
            popUps[popUpIndex].SetActive(false);
        }
    } 

    if (popUpIndex == 0){
        if (Input.GetKeyDown(KeyCode.Space)){
            popUpIndex++;
        }
    }

    }
}
