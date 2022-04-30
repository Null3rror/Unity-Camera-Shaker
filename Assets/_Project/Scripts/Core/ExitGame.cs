using UnityEngine;

namespace _Project.Scripts.Core
{
    public class ExitGame : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
