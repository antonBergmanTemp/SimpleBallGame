using UnityEngine;

public class ChildsEnable : MonoBehaviour
{
    private void OnEnable()
    {
        foreach (Transform item in this.gameObject.transform)
            item.gameObject.SetActive(true);
    }
}
