using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenseControl : MonoBehaviour
{
   public void onClickLoadScene()
   {
        SceneManager.LoadSceneAsync(0);
   }
   public void onClickLoadScene1()
   {
        SceneManager.LoadSceneAsync(1);
   }
   public void onClickLoadScene2()
   {
        SceneManager.LoadSceneAsync(2);
   }
   public void onClickLoadScene3()
   {
        SceneManager.LoadSceneAsync(3);
   }
}
