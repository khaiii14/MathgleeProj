using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;  
    public Button Button_Play;
    public Button Button_Pause;

    void Start()
    {
        Button_Play.onClick.AddListener(TogglePlayPause);
        Button_Pause.onClick.AddListener(TogglePlayPause);

        // Pastikan tombol Pause tersembunyi saat awal
        Button_Pause.gameObject.SetActive(false);
    }

    void TogglePlayPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            Button_Pause.gameObject.SetActive(false);
            Button_Play.gameObject.SetActive(true);
        }
        else
        {
            videoPlayer.Play();
            Button_Play.gameObject.SetActive(false);
            Button_Pause.gameObject.SetActive(true);
        }
    }
}
