using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire = true;
    public float timer;
    public float timeBetweenFiring;
    public GameObject myPlayer;

    // Start is called before the first frame update
    void Start()
    {

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotz);


        //rotate sprite 
        if (rotz< -90 || rotz > 90)
        {
            if (myPlayer.transform.eulerAngles.y == 0)
            {

                transform.localRotation = Quaternion.Euler(180, 0, -rotz);

            }else if (myPlayer.transform.eulerAngles.y == 180)
            {

                transform.localRotation = Quaternion.Euler(180, 180, -rotz);

            }

        }


        //fire rate
        if (!canFire) {

            timer += Time.deltaTime;
            if (timer > timeBetweenFiring) {

                canFire = true;
                timer = 0;
            }

        }


        //fire
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }


    }
}
