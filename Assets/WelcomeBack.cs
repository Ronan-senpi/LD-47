using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeBack : MonoBehaviour
{
    [SerializeField]
    TextMeshPro text;

    [SerializeField]
    TextMeshPro WelcomBack;
    private void Awake()
    {
        int p = PlayerPrefs.GetInt("p", 0);
        p++;
        if (p > 1)
        {
            text.enabled = true;
            text.text = p.ToString();
            WelcomBack.text = "Welcome back in the loop";
        }
    }
}
