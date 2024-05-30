using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DemoLayoutSlider : MonoBehaviour
{
	public Transform trScenes;
	public Text textScene;

	private int _scene;
	private bool _changing;
	private GameObject[] _scenes;
	private U31Panel _lastPanel;

	void Awake ()
	{
		updateScenes(0);
	}

	public void OnBtnPressed(Button btn)
	{
		if (btn.name == "ButtonPrevious")
			updateScenes(-1);
		if (btn.name == "ButtonNext")
			updateScenes(1);
	}

	private void updateScenes(int change)
	{
		if (_changing)
			return;

		_changing = true;

		_scene += change;

		if (_scene < 0)
			_scene = trScenes.childCount - 1;
		if (_scene >= trScenes.childCount)
			_scene = 0;

		textScene.text = string.Format("{0} / {1}", _scene + 1,
			trScenes.childCount);

		U31Panel nextPanel = trScenes.GetChild(_scene).GetComponent<U31Panel>();

		if (_lastPanel != null)
		{
			_lastPanel.HidePanel(() => {
				showPanel(nextPanel);
			});
		}
		else
		{
			showPanel(nextPanel);
		}
	}

	private void showPanel(U31Panel panel)
	{
		StartCoroutine(_showPanel(panel));
	}

    private IEnumerator _showPanel(U31Panel panel)
    {
        yield return new WaitForSeconds(0.3f);

		panel.ShowPanel(() => {
			_changing = false;
			_lastPanel = panel;
		});
    }
}
