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


    public void ShowHp(int hp)
    {
        // Destroy existing health images
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        //int hp = GameManager.playerHp;
        // Instantiate new health images based on the updated player health

        for (int i = 0; i < hp; i++)
        {
            float xPos = i * spacing;
            Vector3 spawnPosition = new Vector3(transform.position.x+xPos, transform.position.y, transform.position.z);

            // Instantiate healthImagePrefab as a child of the current GameObject
            GameObject healthImageInstance = Instantiate(healthImagePrefab, spawnPosition, Quaternion.identity, transform);

            // Optionally, you can rename the instantiated object for clarity
            healthImageInstance.name = "HealthImage" + i;
        }
    }

}
