using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class GameData 
{
 public static List<bool> ishown = new List<bool>();

public static string _saveSetVal= "saveSetVal";

    public static int _matchNumber;//it is random for very next selection
    public static int _userSelectoinNumber;//it is user selected value

 static GameData()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt(_saveSetVal + i, PlayerPrefs.GetInt(_saveSetVal + i));
            ishown.Add(Convert.ToBoolean(PlayerPrefs.GetInt(_saveSetVal + i)));
        }
    }

   public static bool SetResult(int _index,bool _result)
    {
       
        PlayerPrefs.SetInt(_saveSetVal + _index, Convert.ToInt32( _result));
        ishown[_index] = Convert.ToBoolean(PlayerPrefs.GetInt(_saveSetVal + _index));
        
        return _result;
    }
 
}
