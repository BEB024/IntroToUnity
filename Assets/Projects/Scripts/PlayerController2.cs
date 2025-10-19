using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public float speed = 0;

    public AudioClip pickUpSound;
    private AudioSource audioSource;
    private AudioClip clip;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (audioSource != null)
            {
                other.gameObject.SetActive(false);
                audioSource.Play();
            }
            else
            {
                audioSource.PlayOneShot(pickUpSound);
            }
        }
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