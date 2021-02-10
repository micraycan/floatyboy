using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;

    private Rigidbody2D rb;
    private Animator anim;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        anim.SetFloat("velY", rb.velocity.y);

        if (transform.position.y > 4 || transform.position.y < -5)
        {
            Time.timeScale = 0;
            levelManager.ReloadScene();
        }
    }
}
