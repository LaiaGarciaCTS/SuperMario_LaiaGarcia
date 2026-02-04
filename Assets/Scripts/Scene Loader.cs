using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void ChangeScene(string sceneName)
   {
    SceneManager.LoadScene("Level 1");
   }

//Esta es la forma de llamar la funcion ChangeScene a traves de codigo
void Test()
{
    ChangeScene("escena inicio");
}

}
