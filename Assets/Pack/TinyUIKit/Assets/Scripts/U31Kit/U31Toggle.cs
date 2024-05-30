using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class U31Toggle : MonoBehaviour
{
	public GameObject imgOn;
	public GameObject imgOff;

	private Toggle _toggle;
	void Awake()
	{
		_toggle = GetComponent<Toggle>();

		if (imgOn == null || imgOff == null)
		{
			Debug.LogError("Please assign 'imgOn' & 'imgOff' fields.");
			return;
		}

		updateState();
	}

    void OnEnable()
    {
		_toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

	void OnDisable()
    {
		_toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
    }

	private void OnToggleValueChanged(bool value)
	{
        updateState();
    }

    private void updateState()
    {
		imgOn.SetActive(_toggle.isOn);
		imgOff.SetActive(!_toggle.isOn);
    }
}
