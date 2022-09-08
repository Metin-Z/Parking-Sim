using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WaitChecker : MonoBehaviour
{
    public bool IUsed;
    public static int waitCount = 0;
    public int childControl;
    CarSpawnList _carSpawn;
    private void Start()
    {
        _carSpawn = FindObjectOfType<CarSpawnList>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Car"))
        {
            IUsed = true;
            waitCount+=1;
        }       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Car"))
        {           
            IUsed = false;
            waitCount-=1;
        }  
    }
    public void Update()
    {

        if (waitCount % 6 == 0)
        {
            waitCount = 0;
        }
        //if (IUsed == true)
        //{
        //    _carSpawn.WaitPos.Remove(_carSpawn.WaitPos.FirstOrDefault());
        //    _carSpawn.WaitFalsePos.Add(_carSpawn.WaitPos.FirstOrDefault());          
        //}
        //if (IUsed == false)
        //{
        //    _carSpawn.WaitFalsePos.Remove(_carSpawn.WaitFalsePos.FirstOrDefault());
        //    _carSpawn.WaitPos.Add(_carSpawn.WaitFalsePos.FirstOrDefault());
        //}
    }
}
