using UnityEngine;

public class ScreenShowScript : MonoBehaviour
{
    public PlayerController playerController;
    

    public GameObject Screen;
    public GameObject ShowScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DoThings();
    }

    void DoThings()
    {
        if (playerController.mouseDown && playerController.isHoveringOnTriggerbox)
        {
            ShowScreen.SetActive(true); 
            Screen.transform.parent.gameObject.SetActive(false);
        }
    }
}
