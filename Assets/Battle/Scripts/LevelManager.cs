using Map;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    private void Start()
    {
        

    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Map");
        
         MapManager.instance.GenerateNewMap();
            
    }

    public void ResetLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
