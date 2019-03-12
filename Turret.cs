using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject projectileIns;
    [SerializeField] GameObject projectileInsLeft;
    [SerializeField] float shotTimerInitial;
    [SerializeField] string dir;
    [SerializeField] float distanceFromTurret;
    private Player pl;
    private float shotTimer;
    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.Find("Player").GetComponent<Player>();
        shotTimer = shotTimerInitial;
    }

    // Update is called once per frame
    void Update()
    {
        if (pl.hasStoppedTime == false)
        {
            SpawnBullet();
        }
        
    }

    void SpawnBullet()
    {
        shotTimer -= Time.deltaTime;
        if (shotTimer <= 0)
        {
            if (dir == "Right")
            {
                Instantiate(projectileIns, new Vector3(gameObject.transform.position.x + distanceFromTurret, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                shotTimer = shotTimerInitial;
            }
            else if (dir == "Left")
            {
                Instantiate(projectileInsLeft, new Vector3(gameObject.transform.position.x - distanceFromTurret, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                shotTimer = shotTimerInitial;
            }
        }
    }
}
