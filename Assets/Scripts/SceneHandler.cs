using UnityEngine;
using System.Collections;

public class SceneHandler : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        Application.LoadLevel(scene);
    }
}
