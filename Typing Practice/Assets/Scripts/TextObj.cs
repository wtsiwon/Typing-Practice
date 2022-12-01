using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextObj : MonoBehaviour
{
    public string text;

    public Text texttxt;

    private void Start()
    {
        texttxt.text = text;
        GameManager.Instance.currentSpawnString.Add(this);
        print(text);
    }

    private void Update()
    {
        if(text == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.currentSpawnString.Remove(this);
    }
}
