using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarController : MonoBehaviour
{
    CarSpawnList _carSpawn;
    
    void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();
        if (_carSpawn.WaitFalsePos[WaitChecker.waitCount].GetComponent<WaitChecker>().IUsed == false)
        {
            transform.DOMove(new Vector3(
           _carSpawn.WaitFalsePos[WaitChecker.waitCount].position.x,
           _carSpawn.WaitFalsePos[WaitChecker.waitCount].position.y,
           _carSpawn.WaitFalsePos[WaitChecker.waitCount].position.z),
           3.25f);       
        }          
    }
    private void Update()
    {
             
    }
}