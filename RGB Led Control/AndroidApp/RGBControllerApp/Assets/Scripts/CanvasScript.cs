using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {

    public void LoadColorPickerScene()
    {
        Application.LoadLevel(0);
    }
    public void LoadGameScene()
    {       
        Application.LoadLevel(1);
    }
}
