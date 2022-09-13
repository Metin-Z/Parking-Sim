using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExitControl : MonoBehaviour
{
    CarSpawnList _carSpawn;
    public bool Left;
    public bool Right;
    private void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car" && Left == true)
        {
            GameObject obj = other.gameObject;
            other.transform.parent = null;
            other.transform.parent = _carSpawn.EndPos[0];
        }
        if (other.gameObject.tag == "Car" && Right == true)
        {
            other.transform.parent = null;
            other.transform.parent = _carSpawn.EndPos[1].transform;         
        }
    }
    public IEnumerator ColliderStart()
    {
        yield return new WaitForSeconds(1.7f);
        transform.GetComponent<BoxCollider>().enabled = true;
    }
   
}
