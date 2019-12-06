using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ResultChecking : MonoBehaviour
{
    string tagName = "Selectabels";
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log(GameData._userSelectoinNumber+1 +":"+ GameData._matchNumber);
        
        if (GameData._userSelectoinNumber+1 == GameData._matchNumber)
        {
            Gamemanager._inst.ClickOnSlectitem(GameData._userSelectoinNumber);
        }


    }
}
