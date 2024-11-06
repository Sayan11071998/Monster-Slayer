using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healthRestore = 20f;
    public Vector3 spinRotationSpeed = new Vector3(0, 180, 0);

    private void Update()
    {
        transform.eulerAngles += spinRotationSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable damagable = collision.GetComponent<Damagable>();

        if (damagable)
        {
            bool wasHealed = damagable.Heal(healthRestore);

            if (wasHealed)
                Destroy(gameObject);
        }
    }
}
