using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public float speed = 0;

    public AudioClip pickUpSound;
    public AudioSource audioSource;
    private AudioClip clip;

    public TMP_Text scoreText;
    public TMP_Text timerText;

    private int scoreCounter;
    private float timer = 60f;
    private bool isRunning = true;

    void Start()
    {
        scoreCounter = 0;
        scoreText.text = "Score: " + scoreCounter;
        timerText.text = "Time: 1:00";

        rb = GetComponent<Rigidbody>();
        // audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void Update()
    {
        if (isRunning)
        {
            timer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = $"Time: {minutes}:{seconds}";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (audioSource != null)
            {
                other.gameObject.SetActive(false);
                audioSource.Play();
                SetScore();
            }
            else
            {
                audioSource.PlayOneShot(pickUpSound);
            }
        }
    }

    void SetScore()
    {
        scoreCounter += 1;
        scoreText.text = "Score: " + scoreCounter;
    }

    //    //Plays the PickUp's audioSource
    //void OnTriggerEnter(Collider other)
    //{
    //    if (!other.CompareTag("PickUp")) return;

    //    var pickupAS = other.GetComponent<AudioSource>();

    //    if (pickupAS != null)
    //    {
    //        clip = pickupAS.clip;
    //    }
    //    else
    //    {
    //        clip = pickUpSound;
    //    }

    //    if (clip != null)
    //    {
    //        // Spawns a temporary AudioSource at the pickup’s position that persists after disabling
    //        AudioSource.PlayClipAtPoint(clip, other.transform.position,
    //                                    pickupAS ? pickupAS.volume : 1f);
    //    }

    //    other.gameObject.SetActive(false);
    //}

}