using UnityEngine;

namespace OtusProject.MenuButton
{
    public sealed class ExitButton : MonoBehaviour
    {
        public void Exit()
        { 
            Application.Quit();
        }
    }
}

