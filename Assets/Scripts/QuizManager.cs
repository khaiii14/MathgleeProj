using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Text questionText; // Text pertanyaan
    public Button[] answerButtons; // Semua tombol jawaban

    public GameObject PanelUIBenar; // Panel untuk jawaban benar
    public GameObject PanelUISalah;   // Panel untuk jawaban salah

    [SerializeField] private string correctAnswer; // Jawaban benar bisa diatur di Inspector
    private bool isAnswered = false; // Cegah klik lebih dari sekali

    public GameManager gameManager;

    public void CheckAnswer(string buttonName)
    {
        if (isAnswered) return; // Jika sudah dijawab, keluar dari fungsi
        isAnswered = true;

        if (buttonName == correctAnswer) // Cek apakah jawaban benar
        {
            if (PanelUIBenar != null)
                PanelUIBenar.SetActive(true); // Tampilkan panel benar

            if (gameManager.currentSoal == 10)
            {
                gameManager.PopUpMenang();
            }
        }
        else
        {

            if (PanelUISalah != null)
                PanelUISalah.SetActive(true); // Tampilkan panel salah
        }

        // Matikan semua tombol setelah memilih jawaban
        foreach (Button btn in answerButtons)
        {
            btn.interactable = false;
        }
    }
}
