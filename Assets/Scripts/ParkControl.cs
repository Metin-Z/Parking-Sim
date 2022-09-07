using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ParkControl : MonoBehaviour
{
    CarSpawnList _carSpawn;
    public void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            _carSpawn.WaitedCars.Remove(_carSpawn.WaitedCars.FirstOrDefault());
            StartCoroutine(TrafficController());
        }
    }
    public IEnumerator TrafficController(){
        yield return new WaitForSeconds(1.5f);
        _carSpawn.WaitedCars[0].transform.position = new Vector3(_carSpawn.WaitPos[0].position.x, _carSpawn.WaitPos[0].position.y, _carSpawn.WaitPos[0].position.z);
    }
}
