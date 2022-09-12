using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
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
            other.transform.DORotate(new Vector3(0, 0, 0), 1.5f, RotateMode.Fast);
            _carSpawn.WaitedCars.Remove(_carSpawn.WaitedCars.FirstOrDefault());
            StartCoroutine(TrafficController());
            other.transform.parent = null;
            other.transform.parent = _carSpawn.ParkPos[0];
            _carSpawn.ParkPos.Remove(_carSpawn.ParkPos.FirstOrDefault());
            other.GetComponent<CarController>().Move();          
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public IEnumerator TrafficController()
    {
        yield return new WaitForSeconds(1.7f);
        if (_carSpawn.WaitedCars.Count != 0)
        {
            for (int i = 0; i < _carSpawn.WaitedCars.Count; i++)
            {
                _carSpawn.WaitedCars[i].transform.parent = _carSpawn.WaitPos[i];
                _carSpawn.WaitedCars[i].GetComponent<CarController>().Move();
                yield return new WaitForSeconds(0.5f);
            }
            
        }
    }
}