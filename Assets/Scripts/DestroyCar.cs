using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCar : MonoBehaviour
{
    CarSpawnList _carSpawn;
    CanvasManager _canvas;
    private void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();
        _canvas = FindObjectOfType<CanvasManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _canvas.ScoreInt += 1;
        Destroy(other);
        _carSpawn.NewCar();
    }
}
