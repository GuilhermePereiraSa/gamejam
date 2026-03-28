using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRole : MonoBehaviour
{


    public float shieldDuration = 1.5f;

    public float coolDown = 3f;

    private bool isShieldActived = false;
    private float nextAvailableCast = 0f;

    public GameObject shieldObject;
    // Start is called before the first frame update
    void Start()
    {
        if(shieldObject)
            shieldObject.SetActive(false);
    }

    public void AimShield(Vector3 direction)
    {
        if(shieldObject)
        {
            Vector2 dir = (Vector2)(direction - transform.position);

            float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            shieldObject.transform.rotation = Quaternion.Euler(0,0,angulo);
        }
    }

    public void TryActivateShield(Vector3 direction)
    {
        if(Time.time >= nextAvailableCast && isShieldActived == false)
        {
            StartCoroutine("ShieldRoutine");
        }
    }

    public void DeactivateShield()
    {
        if(shieldObject)
            shieldObject.SetActive(false);


        isShieldActived = false;
    }

    IEnumerator ShieldRoutine()
    {
        isShieldActived = true;

        shieldObject.SetActive(true);

        yield return new WaitForSeconds(shieldDuration);

        shieldObject.SetActive(false);
        isShieldActived = false;

        nextAvailableCast = Time.time + coolDown;
    }

}
