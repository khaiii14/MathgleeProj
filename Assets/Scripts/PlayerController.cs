using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick; // Ambil joystick dari UI
    private Rigidbody rb;
    public Animator anim;
    public float rotationSpeed = 100f;

    [SerializeField] private float moveSpeed = 5f; // Atur kecepatan gerakan

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Ambil input dari joystick
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        // Jika ada input dari joystick, karakter bergerak
        if (horizontalInput != 0 || verticalInput != 0)
        {
            // Hitung arah gerakan mengikuti rotasi player
            Vector3 moveDirection = (transform.forward * verticalInput) + (transform.right * horizontalInput);

            // Terapkan kecepatan ke Rigidbody
            rb.velocity = moveDirection * moveSpeed;

            // Animasi berjalan aktif
            anim.SetBool("IsWalking", true);
        }
        else
        {
            // Jika tidak ada input, berhenti
            rb.velocity = Vector3.zero;

            // Animasi berjalan dimatikan
            anim.SetBool("IsWalking", false);
        }
        
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}