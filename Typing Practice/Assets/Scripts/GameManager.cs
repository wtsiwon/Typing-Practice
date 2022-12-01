using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class GameManager : Singleton<GameManager>
{
    public Canvas canvas;

    public GameObject obj;

    public string currentinputField;

    public InputField inputField;

    public List<TextObj> currentSpawnString = new List<TextObj>();

    [Range(0,10)]
    public float spawnTime;

    public bool isSpawn;

    public List<string> strings = new List<string>();

    public float xPos = 700;
    public float yPos = 650;

    private void Start()
    {
        StartCoroutine(nameof(Spawn));
    }


    private void Update()
    {
        Text();
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (isSpawn == true)
            {
                yield return new WaitForSeconds(spawnTime);
                int randText = Random.Range(0, strings.Count);
                TextObj obj = new TextObj();
                print(obj.transform.position);
                obj.transform.SetParent(canvas.transform);
                obj.text = strings[randText];
                int randPosx = Random.Range((int)-xPos, (int)xPos);
                obj.transform.position = new Vector3(randPosx, yPos, 0);
            }
        }
    }

    private void Text()
    {
        currentinputField = inputField.text;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputField.text = null;
            CheckString(currentinputField);
        }
    }

    private void CheckString(string text)
    {
        foreach (TextObj obj in currentSpawnString)
        {
            if (obj.text == text)
            {
                obj.text = null;
            }
        }
    }
}
