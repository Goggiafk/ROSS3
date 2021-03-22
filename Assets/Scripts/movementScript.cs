using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public GameObject platform;
    public GameObject deathScreen;
    public Joystick joystick;
    // Start is called before the first frame update

    public CharacterController2D controller;

    public static float playerSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.xAxis.value * playerSpeed;
    }
    
    public void Crouch()
    {
        crouch = !crouch;
    }
    public void Jump()
    {
        jump = true;
        platform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    }
    
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Fan")
        {
            Debug.Log("fff");
            Time.timeScale = 0;
            deathScreen.SetActive(true);
        }
    }
}
