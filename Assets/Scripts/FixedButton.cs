using UnityEngine;
using UnityEngine.EventSystems;

public class FixedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed = false; // Tambahkan variabel untuk mendeteksi tombol ditekan

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
