using DefaultNamespace;
using UnityEngine;

namespace Test
{
    public class TestClickable: MonoBehaviour, IClickable
    {
        public void OnClick()
        {
            Debug.Log("iclickable");
        }
    }
}