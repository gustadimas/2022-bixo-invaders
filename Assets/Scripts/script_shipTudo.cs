using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_shipTudo : MonoBehaviour
{
    [SerializeField] GameObject prefab_obj_bullet;

    private float bulletCD = 1f;

    private bool bulletCanShoot = true;

    public float shipVelocity;

    Rigidbody2D rb;

    private Animator animator;

    private bool left_collisor;

    private bool right_collisor;

    private float leftcollisor;

    private float rightcollisor;

    private float direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float velocity_horizontal = 0;

        if (Input.GetKey(KeyCode.A))
        {
            velocity_horizontal -= shipVelocity;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity_horizontal += shipVelocity;
        }
        
        rb.velocity = new Vector2(velocity_horizontal, 0);

        //animator.SetBool("Running", Mathf.Abs(rb.velocity.x) > 0.1f || Mathf.Abs(rb.velocity.y) > 0.1f);

        if (Input.GetKeyUp(KeyCode.Space) && bulletCanShoot)
        {
            bulletCanShoot = false;

            Invoke("BulletReset", bulletCD);

            GameObject bullet = Instantiate(prefab_obj_bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);

            bullet.GetComponent<scrip_tiroTudo>().ControlDamage(tag);

            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20), ForceMode2D.Impulse);

            Destroy(bullet, 2f);
        }

        animator.SetBool("fogo", Mathf.Abs(rb.velocity.x) > 0.1f);
    }

    private void BulletReset()
    {
        bulletCanShoot = true;
    }  
}
