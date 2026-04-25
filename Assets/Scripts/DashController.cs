using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour
{

    public float dashSpeed = 15f;

    public float dashDuration = 0.2f;
    public float dashCoolDown = 5f;
    

    Rigidbody2D _rb;

    private float currentDashTime;


    // player controller stop moving - cant move
    private bool canDash = true;
    private bool isDashing = false;

     void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public bool GetisDashing()
    {
        return isDashing;
    }

    // Update is called once per frame  

    public void TryDash(Vector2 mousePos)
    {
        if(canDash && !isDashing)
        {
            StartCoroutine(Dash(mousePos));
            GetComponent<Animator>().SetTrigger("CastDash");
        }
    }


    IEnumerator Dash(Vector2 targetDirection)
    {
        canDash = false;
        isDashing = true;

        
        // cast transform position 
        Vector2 direction = (targetDirection - (Vector2)transform.position).normalized;

        _rb.velocity = direction * dashSpeed;

        // ignora as layers de tiro - tem que config
        Physics2D.IgnoreLayerCollision(6, 8, true);
        Physics2D.IgnoreLayerCollision(6, 7, true);

        yield return new WaitForSeconds(dashDuration);

        // 0x 0y
        _rb.velocity = new Vector2(0f, 0f);

        isDashing = false;


        // volta se tornar possivel
        Physics2D.IgnoreLayerCollision(6, 8, false);
        Physics2D.IgnoreLayerCollision(6, 7, false);


        // retorna apos 1 frame
        yield return new WaitForSeconds(dashCoolDown);

        canDash = true;
    }

}
