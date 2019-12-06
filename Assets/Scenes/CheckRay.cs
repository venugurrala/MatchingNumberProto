using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CheckRay : MonoBehaviour
{
    // Start is called before the first frame update
   RaycastHit hitInfo = new RaycastHit();
  public  string tagName = "Selectabels";
    Vector2 _initialPositon = new Vector2();
    GameObject _objinstance;

    Vector2 _directin = new Vector2();

    Vector2 _onScreenMousePositon;

   public bool _isgoBack;

    float _seconds = 0.5f;
    float timer;
    public float percent;

    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_objinstance != null)
            {
                Destroy(_objinstance);
                _isgoBack = false;
                timer = 0;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {

                if (hitInfo.collider.tag == tagName)
                {
                    _initialPositon = hitInfo.collider.transform.position;
                    _objinstance = Instantiate(hitInfo.collider.gameObject, _initialPositon, Quaternion.identity);
                    _objinstance.tag = "Untagged";
                    _objinstance.transform.localScale = new Vector3(38, 38, 1);


                    GameData._userSelectoinNumber = Convert.ToInt32(hitInfo.collider.name);
                    _isgoBack = false;
                    
                }



            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isgoBack = true;
           // timer = 0;
        }
        if (_objinstance != null)
        {
            if (_isgoBack)
            {
                if (timer <= _seconds)
                {
                    timer += Time.deltaTime;
                    percent = timer / _seconds;
                    _objinstance.transform.position = Vector3.Lerp(new Vector3(_objinstance.transform.position.x, _objinstance.transform.position.y, _objinstance.transform.position.z),
                        new Vector3(_initialPositon.x, _initialPositon.y, _objinstance.transform.position.z), percent); //new Vector2(_objinstance.transform.position.x, _objinstance.transform.position.y) + _directin * percent;
                                                                                                                        //  Vector3.MoveTowards(_objinstance.transform.position, _initialPositon, percent);//new Vector2(_objinstance.transform.position.x, _objinstance.transform.position.y) + _directin * percent;
                }
                else
                {
                    _isgoBack = false;
                    timer = 0;
                    Destroy(_objinstance);
                }


            }
            else
            {
                _objinstance.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y); //GetMouseAsWorldPoint() + mOffset;
            }
        }




    }

    public void AfterSuccesfulSelection()
    {

        _isgoBack = false;
        timer = 0;
        if(_objinstance!=null)
        Destroy(_objinstance);
    }
}
