using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuManager : MonoBehaviour
{

    private PlayerControl inputActions;
    [SerializeField] bool displayMenu = false;
    public GameObject menuPanel;

    private void Awake()
    {
        inputActions = new PlayerControl();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputActions.InGameMenu.ShowMenu.performed += _ => DisplayMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMenu()
    {
        
        if (displayMenu)
        {
            displayMenu = false;
            menuPanel.SetActive(false);
            Time.timeScale = 1f;
            return;
        }
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
        displayMenu = true;
        
    }
}
