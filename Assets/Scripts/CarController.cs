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
        if (_carSpawn.CarWaitPos[WaitChecker.waitCount].GetComponent<WaitChecker>().IUsed == false)
        {
            transform.DOMove(new Vector3(
           _carSpawn.CarWaitPos[WaitChecker.waitCount].position.x,
           _carSpawn.CarWaitPos[WaitChecker.waitCount].position.y,
           _carSpawn.CarWaitPos[WaitChecker.waitCount].position.z),
           4.25f);       
        }          
    }
    private void Update()
    {
             
    }
}