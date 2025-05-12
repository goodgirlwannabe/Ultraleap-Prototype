using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    // For UI.Image

public class FotoController : MonoBehaviour
{
    [Tooltip("Array of sprites to cycle through")]
    public Sprite[] fotoSprites;
    
    [Tooltip("The Image component to change - leave empty if this GameObject has the Image component")]
    public Image targetImage;
    
    private int currentSpriteIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // If no target image is assigned, try to get one from this GameObject
        if (targetImage == null)
        {
            targetImage = GetComponent<Image>();
            
            // If there's still no Image component, check if there's a SpriteRenderer instead
            if (targetImage == null)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    Debug.LogWarning("FotoController: Using SpriteRenderer instead of UI.Image. For UI elements, add an Image component.");
                    // Set initial sprite on the SpriteRenderer
                    if (fotoSprites.Length > 0)
                    {
                        spriteRenderer.sprite = fotoSprites[0];
                    }
                }
                else
                {
                    Debug.LogError("FotoController: No Image or SpriteRenderer component found. Please add one or assign a target Image.");
                }
                return;
            }
        }
        
        // Set initial sprite on the Image component
        if (fotoSprites.Length > 0 && targetImage != null)
        {
            targetImage.sprite = fotoSprites[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call this method from a button to move to the next photo
    public void NextPhoto()
    {
        Debug.Log("NextPhoto");
        
        if (fotoSprites.Length == 0)
        {
            Debug.LogWarning("FotoController: No sprites assigned in the fotoSprites array.");
            return;
        }
        
        // Move to next index (loop back to 0 if we reach the end)
        currentSpriteIndex = (currentSpriteIndex + 1) % fotoSprites.Length;
        
        // Update the sprite
        UpdateSprite();
    }
    
    // Call this method from a button to move to the previous photo
    public void PreviousPhoto()
    {
        Debug.Log("PreviousPhoto");
        
        if (fotoSprites.Length == 0)
        {
            Debug.LogWarning("FotoController: No sprites assigned in the fotoSprites array.");
            return;
        }
        
        // Move to previous index (loop to the end if we're at 0)
        currentSpriteIndex = (currentSpriteIndex - 1 + fotoSprites.Length) % fotoSprites.Length;
        
        // Update the sprite
        UpdateSprite();
    }
    
    // Jump to a specific photo by index
    public void JumpToPhoto(int index)
    {
        if (fotoSprites.Length == 0)
        {
            Debug.LogWarning("FotoController: No sprites assigned in the fotoSprites array.");
            return;
        }
        
        if (index >= 0 && index < fotoSprites.Length)
        {
            currentSpriteIndex = index;
            UpdateSprite();
        }
        else
        {
            Debug.LogError("FotoController: Index out of range: " + index + ". Valid range is 0-" + (fotoSprites.Length - 1));
        }
    }
    
    // Update the sprite on either Image or SpriteRenderer
    private void UpdateSprite()
    {
        if (targetImage != null)
        {
            targetImage.sprite = fotoSprites[currentSpriteIndex];
        }
        else
        {
            // Try SpriteRenderer as fallback
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = fotoSprites[currentSpriteIndex];
            }
        }
    }
}
