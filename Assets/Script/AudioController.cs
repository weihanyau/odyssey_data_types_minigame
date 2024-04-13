using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource player;
    [SerializeField] private AudioClip menuPopUp;
    [SerializeField] private AudioClip buttonPress;
    [SerializeField] private AudioClip success;
    [SerializeField] private AudioClip win;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMenuPopUp()
    {
        player.PlayOneShot(menuPopUp);
    }
    public void PlayButtonPress()
    {
        player.PlayOneShot(buttonPress);
    }
    public void PlaySuccess()
    {
        player.PlayOneShot(success);
    }
    public void PlayWin()
    {
        player.PlayOneShot(win);
    }
}
