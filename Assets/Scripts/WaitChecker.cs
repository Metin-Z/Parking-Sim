using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
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
            other.transform.localScale = new Vector3(0.6f,0.6f,0.6f);
            other.transform.DORotate(new Vector3(0, 0, 0), 1.5f, RotateMode.Fast);
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
    }
}
