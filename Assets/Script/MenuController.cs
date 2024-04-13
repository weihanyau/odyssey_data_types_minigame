using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject CloseButton;
    [SerializeField] GameObject ResetButton;
    [SerializeField] GameObject background;
    AudioController audioController;
    Randomizer randomizer;
    Animator animator;
    TextMeshProUGUI menuText;
    // Start is called before the first frame update
    void Start()
    {
        randomizer = background.GetComponent<Randomizer>();
        audioController = background.GetComponent<AudioController>();
        animator = GetComponent<Animator>();
        menuText = GetComponentInChildren<TextMeshProUGUI>();
        animator.SetTrigger("open");
        audioController.PlayMenuPopUp();
        ResetButton.GetComponent<Button>().onClick.AddListener(randomizer.SetRandomPositionAndText);
        ResetButton.GetComponent<Button>().onClick.AddListener(WhenReset);
        ResetButton.SetActive(false);
        CloseButton.GetComponent<Button>().onClick.AddListener(WhenClose);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator OpenHowToPlay()
    {
        audioController.PlayButtonPress();
        animator.SetTrigger("close");
        yield return new WaitForSecondsRealtime(0.3f);
        menuText.text = "How To Play: \n Match all the Jug to the correct data type according to their label.";
        animator.SetTrigger("open");
        audioController.PlayMenuPopUp();
        CloseButton.GetComponent<Button>().onClick.AddListener(CloseHowToPlay);
    }

    public void WhenClose()
    {
        StartCoroutine(OpenHowToPlay());
        CloseButton.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    public void CloseHowToPlay()
    {
        audioController.PlayButtonPress();
        animator.SetTrigger("close");
        StartCoroutine(AddBackListener());
    }

    public IEnumerator AddBackListener()
    {
        yield return new WaitForSecondsRealtime(1);
        CloseButton.GetComponent<Button>().onClick.RemoveAllListeners();
        CloseButton.GetComponent<Button>().onClick.AddListener(WhenClose);
    }

    public void WhenReset()
    {
        StartCoroutine(OpenIntro());
    }
    public IEnumerator OpenIntro()
    {
        ResetButton.SetActive(false);
        audioController.PlayButtonPress();
        animator.SetTrigger("close");
        yield return new WaitForSecondsRealtime(1);
        CloseButton.SetActive(true);
        menuText.text = "“You are definitely talented in the food industry! I am a good judge of  character; keeping you here will only bury your talent!”\nHence, your boss has transferred you to the beverage department.\n“They say they don’t want to bury talent, yet in the end, they just leave me here filling drinks,” you whispered.\nNever mind, at least this place seems more normal; it should be easier than making burgers ...\nHmm? Wait! The labels on these drinks are?!";
        animator.SetTrigger("open");
        audioController.PlayMenuPopUp();
    }

    public void WhenComplete()
    {
        CloseButton.SetActive(false);
        ResetButton.SetActive(true);
        menuText.text = "“A remarkable talent! Even though it’s only your first day on the job, you’re as skilful as a ten-year expert!” the boss was once again impressed.\n“No, it’s not my first day as a programmer,” you mutter to yourself.\nTill the end, you still don’t understand why we’re using data types to label the drinks, but you are no longer interested in thinking about it.\nPerhaps that’s what they call trade secrets.";
        animator.SetTrigger("open");
        audioController.PlayMenuPopUp();
    }
}
