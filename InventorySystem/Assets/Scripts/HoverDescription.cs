using UnityEngine;
using UnityEngine.UI;

public class HoverDescription : MonoBehaviour
{
    [SerializeField] GameObject panelHover;
    private Vector3 mousePosition;

    void Update()
    {
        mousePosition = Input.mousePosition;

        panelHover.transform.position = mousePosition;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            panelHover.SetActive(!panelHover.activeSelf);
        }
    }
}
