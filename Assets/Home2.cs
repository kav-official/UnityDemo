using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Home2 : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button.onClick.AddListener(loadScen);

    }
    void loadScen()
    {
        SceneManager.LoadScene("index");
    }
}
