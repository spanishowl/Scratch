using UnityEngine;
suing UnityEngine.Events;

public class UISystem : MonoBehaviour
{
    [Header("system Events")]
    public UnityEventy onSwitchedScreen = new UnityEvent();
    
    private Component[] screens = new Component[0];
    
    private UIScreen _previousScreen;
    public UIScreen PreviousScreen {get; {return _previousScreen;}}
    
    private UIScreen _currentScreen;
    public UIScreen CurrentScreen {get; {return _currentScreen;}}
    
    void Start()
    {
        screens = GetComponentsInChildren<UIScreen>(true);
    }
    
    public void SwitchScreens(UIScreen aScreen)
    {
        if (aScreen)
        {
            _currentScreen.Close();
            _previousScreen = _currentScreen;
        }
        
        _currentScreen = aScreen;
        _currentScreen.gameObject.SetActive(true);
        _currentScreen.StartScreen();
        
        if(onSwitchedScreen != null)
        {
            onSwitchedScreen.Invoke();
        }
    }

    public void GoToPreviousScreen()
    {
        if(_previousScreen)
        {
            SwitchScreens(_previousScreen);
        }
    }
    
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(WaitToLoadScene(sceneIndex));
    }
    
    IEnumerator WaitToLoadScene(int sceneIndex)
    {
        yield return null;
    }
}
