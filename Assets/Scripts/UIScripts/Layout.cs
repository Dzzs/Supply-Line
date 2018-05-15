using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Scale a GridLayoutGroup according to resolution, etc.
 * This is using width-constrained layout
 */
public class Layout : MonoBehaviour
{
    public int col, row;

    private void Start()
    {
        RectTransform parent = gameObject.GetComponent<RectTransform>();
        GridLayoutGroup grid = gameObject.GetComponent<GridLayoutGroup>();

        grid.cellSize = new Vector2(parent.rect.width / col, parent.rect.height / row);
    }
}