using UnityEngine;
using UnityEngine.UI;

public class DemoDropDown : MonoBehaviour
{
	public Transform trSections;

	private Transform _lastSection;

	void Awake()
	{
		_lastSection = trSections.GetChild(0).transform;
	}

	public void OnDropdownValueChanged (Dropdown dd)
	{
		_lastSection.GetComponent<DemoLayoutSlider>().trScenes.gameObject.SetActive(false);
		_lastSection.gameObject.SetActive(false);

		_lastSection = trSections.GetChild(dd.value);

		_lastSection.GetComponent<DemoLayoutSlider>().trScenes.gameObject.SetActive(true);
		_lastSection.gameObject.SetActive(true);
	}
}
