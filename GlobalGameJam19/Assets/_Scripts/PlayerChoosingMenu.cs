using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerChoosingMenu : MonoBehaviour
{
    public List<GameObject> playerWindows;
    public List<TextMeshProUGUI> playerTexts;
    int currentWindow = 0;
    bool key1, key2;
    protected List<int> padsUsed = new List<int>();
    public GameObject presInfo;

    public GameObject startGameButton;

    private void Awake()
    {
        if (CustomPlayerSpawner.customInfo == null) CustomPlayerSpawner.customInfo = new List<DebugPlayerSpawnInformation>();
    }

    private void Start()
    {
        startGameButton.SetActive(false);
        foreach (GameObject window in playerWindows)
        {
            window.SetActive(false);
        }
        presInfo.SetActive(false);
    }

    private void OnEnable()
    {
        ClearStuff();
    }

    void Update()
    {
        if (!MainMenu.dupa) return;
        if (currentWindow > 0) startGameButton.SetActive(true);

        if (currentWindow >= 4) return;
        if(!key1 && Input.GetKeyDown(KeyCode.W))
        {
            key1 = true;
            playerWindows[currentWindow].SetActive(true);
            CustomPlayerSpawner.customInfo.Add(new DebugPlayerSpawnInformation(PlayerEntity.PlayerControllerType.Keyboard));
            playerTexts[currentWindow].text = "PLAYER " + (currentWindow + 1).ToString() + "\n" + "KEYBOARD";
            currentWindow++;
            presInfo.SetActive(false);
        }
        if(!key2 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            key2 = true;
            playerWindows[currentWindow].SetActive(true);
            CustomPlayerSpawner.customInfo.Add(new DebugPlayerSpawnInformation(PlayerEntity.PlayerControllerType.Keyboard));
            playerTexts[currentWindow].text = "PLAYER " + (currentWindow + 1).ToString() + "\n" + "KEYBOARD";
            currentWindow++;
            presInfo.SetActive(false);
        }

        for(int i = 0; i < InputManager.ActiveDevices.Count; i++)
        {
            if(!padsUsed.Contains(i))
            {
                if(InputManager.ActiveDevices[i].Action1)
                {
                    padsUsed.Add(i);
                    playerWindows[currentWindow].SetActive(true);
                    CustomPlayerSpawner.customInfo.Add(new DebugPlayerSpawnInformation(PlayerEntity.PlayerControllerType.Pad));
                    playerTexts[currentWindow].text = "PLAYER " + (currentWindow + 1).ToString() + "\n" + "PAD";
                    currentWindow++;
                    presInfo.SetActive(false);
                }
            }
        }
    }

    public void StartGame()
    {
        MainMenu.dupa = false;
        if (currentWindow > 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Cancel()
    {
        ClearStuff();
        FindObjectOfType<MainMenu>().CancelPlay();
    }

    public void ClearStuff()
    {
        CustomPlayerSpawner.customInfo.Clear();
        key1 = key2 = false;
        padsUsed.Clear();
        currentWindow = 0;
        foreach (GameObject window in playerWindows)
        {
            window.SetActive(false);
        }
        presInfo.SetActive(true);
        startGameButton.SetActive(false);
        MainMenu.dupa = false;
    }
}
