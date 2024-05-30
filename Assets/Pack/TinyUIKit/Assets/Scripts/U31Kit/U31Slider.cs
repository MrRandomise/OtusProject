using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class U31Slider : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
	public float step = 0.1f;
	public Button btnMinus;
	public Button btnPlus;

	private Slider _slider;
	private bool _interactionDisabled;
	private Canvas _canvas;

	void Awake()
	{
		_slider = GetComponent<Slider>();

		if (btnMinus == null || btnPlus == null)
		{
			Debug.LogError("Please assign 'btnMinus' & 'btnPlus' fields.");
			return;
		}
	}
	
    void OnEnable()
    {
		if (btnMinus != null && btnPlus != null)
		{
			btnMinus.onClick.AddListener(decreaseSliderValue);
			btnPlus.onClick.AddListener(increaseSliderValue);
		}

		_canvas = GetComponentInParent<Canvas>();
    }

	void OnDisable()
    {
		if (btnMinus != null && btnPlus != null)
		{
			btnMinus.onClick.RemoveListener(decreaseSliderValue);
			btnPlus.onClick.RemoveListener(increaseSliderValue);
		}
    }

	private void increaseSliderValue()
	{
		_slider.value += step;
	}

	private void decreaseSliderValue()
	{
		_slider.value -= step;
	}

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
		_interactionDisabled = false;

		Camera cam = null;
		if (_canvas.renderMode != RenderMode.ScreenSpaceOverlay)
			cam = _canvas.worldCamera;

		bool minus = RectTransformUtility.RectangleContainsScreenPoint(
			(RectTransform)btnMinus.transform,
			eventData.position,
			cam
		);

		bool plus = RectTransformUtility.RectangleContainsScreenPoint(
			(RectTransform)btnPlus.transform,
			eventData.position,
			cam
		);

		_interactionDisabled = minus || plus;

		if (_interactionDisabled)
			_slider.interactable = false;

		if (minus)
			decreaseSliderValue();

		if (plus)
			increaseSliderValue();
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
		if (_interactionDisabled)
			_slider.interactable = true;

		_interactionDisabled = false;
    }
}
