using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Image image;
    Color originalColor;
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.color = Color.red;
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.color = originalColor;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 50, LayerMask.GetMask("Interactable"));
        if (hit.collider != null)
        {
            Debug.Log($"You have combined {gameObject.name} with {hit.transform.gameObject.name}");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
