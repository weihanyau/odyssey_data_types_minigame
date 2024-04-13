using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject background;
    AudioController audioController;

    public static int winCount = 0;
    public static int correctCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioController = background.GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (correctCount == 5)
        {
            audioController.PlaySuccess();
            correctCount = 0;
            winCount++;
            background.GetComponent<Randomizer>().SetRandomPositionAndText();
        }
        if (winCount == 5)
        {
            winCount = 0;
            menu.GetComponent<MenuController>().WhenComplete();
        }
    }
}
