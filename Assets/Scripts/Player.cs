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
            int layer = 7;
            if (Physics.Raycast(Point, out collision, 1<< layer))
            {
                Collider[] collisions = Physics.Raycast(collision.point,Vector3.forward,5f,layer);                  
                foreach (var cars in collisions)
                {
                    Rigidbody rb = cars.GetComponent<Rigidbody>();
                    if (rb!=null)
                    {
                        Barrier.transform.DORotate(new Vector3(0, 0, -60), 1.5f, RotateMode.Fast).OnComplete(
                            () =>
                            {
                                Barrier.transform.DORotate(new Vector3(0, 0, 0), 1.5f, RotateMode.Fast);
                            });
                        cars.transform.parent = null;
                        cars.transform.parent = _ParkControl.transform;
                        cars.GetComponent<CarController>().Move();
                    }                   
                }
            }
            Debug.DrawRay(Point.origin, Point.direction * 10f, Color.cyan);
        }
    }
    // DOMove(new Vector3(0.28f, 0.05f, 1), 9.069f);
}
