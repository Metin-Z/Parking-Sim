using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarController : MonoBehaviour
{
    CarSpawnList _carSpawn;
    public bool CarMove = true;
    void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();     
    }
    private void Update()
    {    
        if (_carSpawn.WaitFalsePos[0].GetComponent<WaitChecker>().IUsed == false && CarMove == true)
        {         
            transform.DOMove(new Vector3(
           _carSpawn.WaitFalsePos[0].position.x,
           _carSpawn.WaitFalsePos[0].position.y,
           _carSpawn.WaitFalsePos[0].position.z),
           2.75f);        
            if (transform.position == _carSpawn.WaitFalsePos[0].transform.position)
            {
                Debug.Log("Bool");
                CarMove = false;
            }
        }
    }
}