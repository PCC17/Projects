using UnityEngine;

public class ColorIndicator : MonoBehaviour
{

    [SerializeField]
    private SenderScript scriptLogic;

    HSBColor color;

	void Start() {
		color = HSBColor.FromColor(GetComponent<Renderer>().sharedMaterial.GetColor("_Color"));
		transform.parent.BroadcastMessage("SetColor", color);
	}

	void ApplyColor ()
	{
		GetComponent<Renderer>().sharedMaterial.SetColor ("_Color", color.ToColor());
		transform.parent.BroadcastMessage("OnColorChange", color, SendMessageOptions.DontRequireReceiver);
        scriptLogic.SendData(new []{ (byte)(color.ToColor().r *255), (byte)(color.ToColor().g * 255), (byte)(color.ToColor().b * 255), });
	}

	void SetHue(float hue)
	{
		color.h = hue;
		ApplyColor();
    }	

	void SetSaturationBrightness(Vector2 sb) {
		color.s = sb.x;
		color.b = sb.y;
		ApplyColor();
	}
}
