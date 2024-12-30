using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
        }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            GameManager.instance.ActivateTitleScreen();
        }
        if(Input.GetKey(KeyCode.H))
        {
            GameManager.instance.ActivateMainMenu();
        }
        if(Input.GetKey(KeyCode.J))
        {
            GameManager.instance.ActivateOptionsScreen();
        }
        if(Input.GetKey(KeyCode.K))
        {
            GameManager.instance.ActivateCreditsScreen();
        }
        if(Input.GetKey(KeyCode.L))
        {
            GameManager.instance.ActivateGameplay();
        }
        if(Input.GetKey(KeyCode.F))
        {
            GameManager.instance.ActivateGameOverScreen();
        }
    }
}
