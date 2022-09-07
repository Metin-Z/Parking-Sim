using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    RaycastHit collision;
    Vector3 Cursor;
    ParkControl _ParkControl;
    public GameObject Barrier;
    private void Start()
    {
        _ParkControl = FindObjectOfType<ParkControl>();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray Point = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Point, out collision))
            {
                Collider[] collisions = Physics.OverlapSphere(collision.point, 0.3f);

                foreach(var cars in collisions)
                {
                    Rigidbody rb = cars.GetComponent<Rigidbody>();
                    if (rb!=null)
                    {
                        Barrier.transform.DORotate(new Vector3(-60, 0, 0),1.5f, RotateMode.Fast).OnComplete(
                            ()=>{
                                Barrier.transform.DORotate(new Vector3(0, 0, 0), 1.5f, RotateMode.WorldAxisAdd);
                                });
                        cars.transform.parent = null;
                        cars.transform.parent = _ParkControl.transform;
                    }                   
                }
            }
            Debug.DrawRay(Point.origin, Point.direction * 10f, Color.cyan);
        }
    }
    // DOMove(new Vector3(0.28f, 0.05f, 1), 9.069f);
}
