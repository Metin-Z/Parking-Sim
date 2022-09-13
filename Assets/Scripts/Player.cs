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
    ExitControl _exitControl;
    public GameObject Barrier;
    public GameObject BarrierLeft;
    public GameObject BarrierRight;
    public GameObject LeftHouse;
    public GameObject RightHouse;
    int randomSide;
    private void Start()
    {
        _ParkControl = FindObjectOfType<ParkControl>();
        _carSpawn = FindObjectOfType<CarSpawnList>();
        _exitControl = FindObjectOfType<ExitControl>();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray Point = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layer = 7;
            int layer2 = 8;
            if (Physics.Raycast(Point, out collision, Mathf.Infinity, 1 << layer))
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
                randomSide = Random.Range(0, 2);
                collision.transform.parent = null;
                collision.transform.parent = _carSpawn.ExitPos[randomSide];
                collision.transform.GetComponent<CarController>().Move();
                if (randomSide == 0)
                {
                    BarrierLeft.transform.DORotate(new Vector3(60, 0, 0), 1.5f, RotateMode.Fast).OnComplete(
                () =>
                {
                    BarrierLeft.transform.DORotate(new Vector3(0, 0, 0), 2f, RotateMode.Fast);
                });
                }
                if (randomSide == 1)
                {
                    BarrierRight.transform.DORotate(new Vector3(60, 0,0), 1.5f, RotateMode.Fast).OnComplete(
                () =>
                {
                    BarrierRight.transform.DORotate(new Vector3(0, 0, 0), 2f, RotateMode.Fast);
                });
                }
                StartCoroutine(ExitCollider());
            }
            Debug.DrawRay(Point.origin, Point.direction * 10f, Color.cyan);
        }
    }
    public IEnumerator ParkCollider()
    {
        yield return new WaitForSeconds(2f);
        _ParkControl.GetComponent<BoxCollider>().enabled = true;
    }public IEnumerator ExitCollider()
    {
        yield return new WaitForSeconds(1.75f);
        _carSpawn.ExitPos[0].GetComponent<BoxCollider>().enabled = true;
        _carSpawn.ExitPos[1].GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(1.75f);
        _carSpawn.ExitPos[0].GetComponent<BoxCollider>().enabled = false;
        _carSpawn.ExitPos[1].GetComponent<BoxCollider>().enabled = false;
    }

}
