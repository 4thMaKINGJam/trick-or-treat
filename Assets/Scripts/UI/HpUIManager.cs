using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HpUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject healthImagePrefab;
    private float spacing = 0.8f; // Adjust this value to set the spacing between health images

    public void Start()
    {
        int hp = GameManager.playerHp;

        for (int i = 0; i < hp; i++)
        {
            float xPos = transform.position.x + i * spacing;
            Vector3 spawnPosition = new Vector3(xPos, 0, 0);
            //Instantiate(healthImagePrefab, spawnPosition, Quaternion.identity);

            // Instantiate healthImagePrefab as a child of the current GameObject
            GameObject healthImageInstance = Instantiate(healthImagePrefab, spawnPosition, Quaternion.identity, transform);

            // Optionally, you can rename the instantiated object for clarity
            healthImageInstance.name = "HealthImage" + i;
        }
    }
}
