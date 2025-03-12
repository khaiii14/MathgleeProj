using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform player; // Referensi ke karakter utama
    public Vector3 offset = new Vector3(0, 5, -5); // Posisi default kamera terhadap karakter
    public float smoothSpeed = 5f; // Kecepatan pergerakan kamera
    public float minDistance = 2f; // Jarak minimum kamera ke karakter
    public float maxDistance = 4f; // Jarak maksimum kamera ke karakter
    public LayerMask obstacleMask; // Layer yang akan dianggap sebagai penghalang
    //float minYAngle = 10f; // Sudut minimum yang diizinkan
    //float maxYAngle = 70f; // Sudut maksimum yang diizinkan

    private void LateUpdate()
    {
        // Hitung posisi target kamera
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);
        Vector3 direction = (desiredPosition - player.position).normalized;

        // Gunakan Raycast untuk mendeteksi dinding
        RaycastHit hit;
        if (Physics.Raycast(player.position, direction, out hit, maxDistance, obstacleMask))
        {
            // Jika ada penghalang, tempatkan kamera lebih dekat
            float adjustedDistance = Mathf.Lerp(minDistance, maxDistance, 0.5f);
            transform.position = Vector3.Lerp(transform.position, player.position + direction * adjustedDistance, smoothSpeed * Time.deltaTime);

        }
        else
        {
            // Jika tidak ada penghalang, gunakan posisi normal
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }

        // Kamera selalu melihat ke karakter
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}
