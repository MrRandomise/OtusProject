using UnityEngine;
using UnityEngine.UI;

public class DemoSupport : MonoBehaviour
{

	public void OnButtonPressed(Button btn)
	{
		if (btn.name == "ButtonYouTube")
		{
			Application.OpenURL("https://www.youtube.com/watch?v=kpsbVpBCEQ0");
		}

		if (btn.name == "ButtonPage")
		{
			Application.OpenURL("https://bigwhiteplanet.com/assets/tiny-ui-kit/");
		}

		if (btn.name == "ButtonSopport")
		{
			Application.OpenURL("https://bigwhiteplanet.com/support/");
		}
	}

}
