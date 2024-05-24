using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniMartUI
{
    public class ItemUIElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _image;

        public void ChangeText(string newText)
        {
            _text.text = newText;
        }

        public void ChangeSprite(Sprite newSprite)
        {
            _image.sprite = newSprite;
        }
    }

}