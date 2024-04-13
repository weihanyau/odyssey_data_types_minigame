using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Randomizer : MonoBehaviour
{
    [SerializeField] GameObject stringJugObj;
    [SerializeField] GameObject intJugObj;
    [SerializeField] GameObject charJugObj;
    [SerializeField] GameObject boolJugObj;
    [SerializeField] GameObject doubleJugObj;
    List<string> stringJug = new List<string>();
    List<string> intJug = new List<string>();
    List<string> charJug = new List<string>();
    List<string> boolJug = new List<string>();
    List<string> doubleJug = new List<string>();
    List<Vector2> intPosition = new List<Vector2>();
    void Start()
    {


        stringJug.Add("\"a\"");
        stringJug.Add("\"World\"");
        stringJug.Add("\"abcde\"");
        stringJug.Add("\"53\"");
        stringJug.Add("\"24.24\"");

        intJug.Add("1");
        intJug.Add("512");
        intJug.Add("16");
        intJug.Add("-10");
        intJug.Add("-54");

        charJug.Add("'a'");
        charJug.Add("'   '");
        charJug.Add("'1'");
        charJug.Add("'U'");
        charJug.Add("'A'");

        boolJug.Add("false");
        boolJug.Add("true");

        doubleJug.Add("24.24");
        doubleJug.Add("21.234");
        doubleJug.Add("0.001");
        doubleJug.Add("0.2");
        doubleJug.Add("1.2");

        intPosition.Add(new Vector2(24.04f, 15.33f));
        intPosition.Add(new Vector2(27.31f, 12.86f));
        intPosition.Add(new Vector2(22.09f, 15.31f));
        intPosition.Add(new Vector2(28.91f, 11.76f));
        intPosition.Add(new Vector2(25.83f, 11.69f));

        SetRandomPositionAndText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetString()
    {
        int randomIndex = Random.Range(0, stringJug.Count);
        return stringJug[randomIndex];
    }
    public string GetChar()
    {
        int randomIndex = Random.Range(0, charJug.Count);
        return charJug[randomIndex];
    }
    public string GetInt()
    {
        int randomIndex = Random.Range(0, intJug.Count);
        return intJug[randomIndex];
    }
    public string GetBool()
    {
        int randomIndex = Random.Range(0, boolJug.Count);
        return boolJug[randomIndex];
    }
    public string GetDouble()
    {
        int randomIndex = Random.Range(0, doubleJug.Count);
        return doubleJug[randomIndex];
    }

    public void SetRandomPositionAndText()
    {
        List<Vector2> intPositionClone = new List<Vector2>();
        intPosition.ForEach((item) =>
        {
            intPositionClone.Add(item);
        });
        List<GameObject> objPosition = new List<GameObject>();
        objPosition.Add(stringJugObj);
        objPosition.Add(intJugObj);
        objPosition.Add(boolJugObj);
        objPosition.Add(charJugObj);
        objPosition.Add(doubleJugObj);
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, intPositionClone.Count);
            objPosition[i].GetComponent<DragandDrop>().correct = false;
            TextMeshProUGUI text = objPosition[i].GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log(objPosition[i].transform.position);
            if (i == 0)
            {
                text.text = GetString();
            }
            else if (i == 1)
            {
                text.text = GetInt();
            }
            else if (i == 2)
            {
                text.text = GetBool();
            }
            else if (i == 3)
            {
                text.text = GetChar();
            }
            else if (i == 4)
            {
                text.text = GetDouble();
            }
            objPosition[i].transform.position = intPositionClone[randomIndex];
            intPositionClone.RemoveAt(randomIndex);
            objPosition[i].GetComponent<DragandDrop>().newPosition();
        }
    }
}
