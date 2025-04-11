using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
    public GameObject Panel; // Panel soal quiz

    private void Start()
    {
        // Panel disembunyikan di awal
        if (Panel != null)
            Panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Panel != null)
                Panel.SetActive(true); // Tampilkan panel saat player masuk titik
        }
    }
}
