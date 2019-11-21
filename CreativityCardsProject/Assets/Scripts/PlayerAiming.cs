using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject player;
    public Camera mainCamera;
    public GameObject projectile;
    public GameObject firePoint;
    public float projectileSpeed;
    public float minRot;
    public float maxRot;
    public PlayerMovement pMove;
    public AudioSource fuck;

    private Vector3 target;

    
    private void Start()
    {
        Cursor.visible = false;
        fuck = GetComponent<AudioSource>();
    }

    
    private void Update()
    {
        target = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);
        Vector3 characterScale = transform.localScale;

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
        if((rotationZ >= minRot) && (rotationZ <= maxRot))
        {
            player.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }

        if((rotationZ <= 90))
        {
            transform.localScale = characterScale;
        }


        if (Input.GetMouseButtonDown(0))
        {
            fuck.Play();
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireBullet(direction, rotationZ);

        }
    }
    void FireBullet(Vector2 direction, float rotationZ)
    {
        //Vector3 firingDir = direction;

        //if (pMove.facingRight)
        //{

        //}


        GameObject proj = Instantiate(projectile, firePoint.transform.position, Quaternion.Euler(0.0f, 0.0f, rotationZ)) as GameObject;
        proj.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

}
