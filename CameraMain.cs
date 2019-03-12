using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    [SerializeField] GameObject pl;
    [SerializeField] float boundsY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        gameObject.transform.position = new Vector3(pl.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        if (pl.transform.position.y > gameObject.transform.position.y + boundsY || pl.transform.position.y < gameObject.transform.position.y - boundsY)
        {
            gameObject.transform.position = new Vector3(pl.transform.position.x, pl.transform.position.y, gameObject.transform.position.z);
        }
    }
}
