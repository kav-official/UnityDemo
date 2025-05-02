using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Home3 : MonoBehaviour
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
