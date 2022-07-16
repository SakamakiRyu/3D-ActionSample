using UnityEngine;
using UnityEngine.UI;

public class CrossHairController : MonoBehaviour
{
    [SerializeField]
    private GrappleGun _grappleGun;

    [SerializeField]
    private Image _crossHairImage;

    [SerializeField]
    private Color _colorOfCanGrapple;

    [SerializeField]
    private Color _colorOfCantCrapple;

    private void Start()
    {
        _crossHairImage.color = _colorOfCantCrapple;
    }

    private void Update()
    {
        ColorChenge();
    }

    private void ColorChenge()
    {
        Color afterColor;

        switch (_grappleGun.IsGrappleable)
        {
            case true:
                afterColor = _colorOfCanGrapple;
                break;

            case false:
                afterColor = _colorOfCantCrapple;
                break;
        }

        _crossHairImage.color = afterColor;
    }
}
