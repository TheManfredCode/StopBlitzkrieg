using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Preloader :MonoBehaviour
    {
        [SerializeField] private TMP_Text _errorLogLabel;
        [SerializeField] private Button _reload;
    }
}