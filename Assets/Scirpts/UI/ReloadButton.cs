using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadButton : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
