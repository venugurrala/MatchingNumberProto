using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Gamemanager : MonoBehaviour
{
   

    public List<GameObject> Items;

   public TextMesh txt_resutToshow;

    List<int> _remainigToMatch = new List<int>();
    public static Gamemanager _inst;

    public CheckRay _checkRay;
    public GameObject panel_Winner;
    public Material white, block;
    void Start()
    {
    panel_Winner.SetActive(false);
    _inst = this;

        SetNextValueFromRemaining();

    }


    public void ClickOnSlectitem(int SelectedItem)
    {
        if (!_checkRay._isgoBack)
        {
            GameData.SetResult(SelectedItem, true);
            _checkRay.AfterSuccesfulSelection();
            SetNextValueFromRemaining();
        }
    }
  void SetNextValueFromRemaining()
    {

       
        int _totalItelms = GameData.ishown.Count;

        _remainigToMatch.Clear();
        for (int i = 0; i < _totalItelms; i++)
        {
            if (GameData.ishown[i])
            {
                //continue;
                Items[i].tag = "Untagged";
                Items[i].GetComponent<Renderer>().material = block;
            }
            else
            {
                Items[i].tag=_checkRay.tagName;
                Items[i].GetComponent<Renderer>().material = white;
                _remainigToMatch.Add(i+1);
            }
        }

       /* for (int i = 0; i < _remainigToMatch.Count; i++)
        {
            Debug.Log(_remainigToMatch[i]);
        }*/
        if (_remainigToMatch.Count == 0)
        {
            Debug.Log("Winning");
            panel_Winner.SetActive(true);
            return;
        }
        else if (_remainigToMatch.Count == 1)
        {
            GameData. _matchNumber = _remainigToMatch[0];
        }
        else
        {
            GameData. _matchNumber = Convert.ToInt32( _remainigToMatch[UnityEngine.Random.Range(0, _remainigToMatch.Count-1)]);
        }
            txt_resutToshow.text = GameData._matchNumber+"";
    }
    public void ClrPrf()
    {
        _checkRay.AfterSuccesfulSelection();

        for (int i = 0; i < GameData.ishown.Count; i++)
        {

            GameData.SetResult(i, false);
        }
        panel_Winner.SetActive(false);
        SetNextValueFromRemaining();

    }

    
}
