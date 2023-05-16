using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource buttonSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonSound.Play();
    }
}