using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [Header("background settings")]
    [SerializeField] protected int backgroundNum; // background image count (stage height)
    [SerializeField] protected int backgroudRoutine = 2; // background image routine count
    [SerializeField] protected GameObject[] backgroundPrefabs; // background sprites

    protected void Start()
    {
        CreateBackground(); // create background
    }

    // create background
    private void CreateBackground()
    {
        if (backgroundPrefabs.Length == 0)
        {
            return;
        }
        float startPoint = -backgroundPrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.y * backgroundPrefabs[0].GetComponent<Transform>().localScale.y;
        for (int i = 0; i < backgroundNum; i++)
        {
            startPoint = CreateOneBackground(backgroundPrefabs[i % backgroudRoutine], startPoint);
        }
        // top background
        CreateOneBackground(backgroundPrefabs[backgroundPrefabs.Length - 1], startPoint);
    }
    private float CreateOneBackground(GameObject obj, float startPoint)
    {
        float height = obj.GetComponent<SpriteRenderer>().sprite.bounds.size.y * obj.GetComponent<Transform>().localScale.y;
        float newY = startPoint + height;

        Vector2 creatingPoint = new Vector2(0, newY);
        GameObject temp = Instantiate(obj, creatingPoint, Quaternion.identity);
        temp.transform.SetParent(this.gameObject.transform.Find("Background").transform);

        return startPoint + height;
    }

    // get stage length
    public float GetStageHeight()
    {
        float oneHeight = backgroundPrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.y * backgroundPrefabs[0].GetComponent<Transform>().localScale.y;
        return backgroundNum * oneHeight - oneHeight / 3.5f;
    }
}
