using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
public class Player : MonoBehaviour
{
    RaycastHit collision;
    ParkControl _ParkControl;
    CarSpawnList _carSpawn;
    public GameObject Barrier;
    private void Start()
    {
        _ParkControl = FindObjectOfType<ParkControl>();
        _carSpawn = FindObjectOfType<CarSpawnList>();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray Point = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layer = 7;
            int layer2 = 8;
            if (Physics.Raycast(Point, out collision,Mathf.Infinity, 1 << layer))
            {                
                Barrier.transform.DORotate(new Vector3(0, 0, -60), 1.5f, RotateMode.Fast).OnComplete(
                () =>
                   {
                       Barrier.transform.DORotate(new Vector3(0, 0, 0), 1.5f, RotateMode.Fast);
                   });
                collision.transform.parent = null;
                collision.transform.parent = _ParkControl.transform;
                collision.transform.GetComponent<CarController>().Move();
                StartCoroutine(ParkCollider());
            }
            if (Physics.Raycast(Point, out collision, Mathf.Infinity, 1 << layer2))
            {
                Debug.Log("Parktan Çýk");
                collision.transform.parent = null;
                collision.transform.parent = _carSpawn.ExitPos[Random.Range(0, 2)];
                collision.transform.GetComponent<CarController>().Move();
                
            }
            Debug.DrawRay(Point.origin, Point.direction * 10f, Color.cyan);
        }
    }
    public IEnumerator ParkCollider()
    {
        yield return new WaitForSeconds(2f);
        _ParkControl.GetComponent<BoxCollider>().enabled = true;
    }
   
}
