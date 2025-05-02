using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Homes : MonoBehaviour
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
