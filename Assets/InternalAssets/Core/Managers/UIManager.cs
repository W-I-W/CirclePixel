using System;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public UIDocument UIGameOver;
    public UIDocument UIWin;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {

        UIGameOver.enabled = false;
        UIWin.enabled = false;
    }

    public void UIEnable(UIDocument ui)
    {
        ui.enabled = true;
        ui.rootVisualElement.Q<Button>("Restart").clicked += RestartGame;
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
