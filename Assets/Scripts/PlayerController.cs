using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sr;
    Animator animator;

    [SerializeField]
    float jumpForce;

    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    float threshold = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        jumpForce = 600.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // 컴퓨터 버전
        //if (Input.GetKeyDown(KeyCode.Space) && rigid.velocity.y == 0)
        //{
        //    this.rigid.AddForce(transform.up * this.jumpForce);
        //    animator.SetBool("isWalk", false);
        //    animator.SetBool("isJump", true);
        //}

        // 스마트폰 버전
        if(Input.GetMouseButtonDown(0) && rigid.velocity.y == 0)
        {
            this.rigid.AddForce(transform.up * this.jumpForce);
            animator.SetBool("isWalk", false);
            animator.SetBool("isJump", true);
        }

        int ky = 0;
        // 컴퓨터 버전
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    ky = 1;
        //    sr.flipX = false;
        //    animator.SetBool("isWalk", true);
        //    animator.SetBool("isJump", false);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    ky = -1;
        //    sr.flipX = true;
        //    animator.SetBool("isWalk", true);
        //    animator.SetBool("isJump", false);
        //}

        // 스마트폰 버전
        if(Input.acceleration.x > this.threshold)
        {
            ky = 1;
            sr.flipX = false;
            animator.SetBool("isWalk", true);
            animator.SetBool("isJump", false);
        }
        if (Input.acceleration.x < this.threshold)
        {
            ky = -1;
            sr.flipX = true;
            animator.SetBool("isWalk", true);
            animator.SetBool("isJump", false);
        }
        float speedX = Mathf.Abs(this.rigid.velocity.x);

        if (speedX < this.maxWalkSpeed)
        {
            this.rigid.AddForce(transform.right * this.walkForce * ky);
        }

        animator.speed = speedX / 2.0f;

        if (Mathf.Abs(transform.position.x) > 2.5f || transform.position.y < -6.0f)
        {
            transform.localPosition = new Vector3(0, -4.0f, 0);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("flag"))
        {
            Debug.Log("Complete");
            SceneManager.LoadScene("ClearScene");
        }
    }

}
