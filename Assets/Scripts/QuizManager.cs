using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Text questionText; // Text pertanyaan
    public Text feedbackText; // Text feedback
    public Button[] answerButtons; // Semua tombol jawaban
    
    [SerializeField] private string correctAnswer; // Jawaban benar bisa diatur di Inspector
    private bool isAnswered = false; // Cegah klik lebih dari sekali

    public void CheckAnswer(string buttonName)
    {
        if (isAnswered) return; // Jika sudah dijawab, keluar dari fungsi
        isAnswered = true;

        if (buttonName == correctAnswer) // Cek apakah jawaban benar
        {
            feedbackText.text = "Jawaban Benar!";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "Jawaban Salah!";
            feedbackText.color = Color.red;
        }

        // Matikan semua tombol setelah memilih jawaban
        foreach (Button btn in answerButtons)
        {
            btn.interactable = false;
        }
    }
}
