using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float destroyDelay;
    private float timer;

    private void Update()
    {
        timer += 1f * Time.deltaTime;

        if (timer > destroyDelay)
        {
            Destroy(this.gameObject);
        }
    }
}
