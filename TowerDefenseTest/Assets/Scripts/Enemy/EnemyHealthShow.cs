using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthShow : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private TextMeshProUGUI _text;

	private int _maxValue;
	Quaternion _cameraRot;

	private void Awake()
	{
		_cameraRot = Camera.main.transform.rotation;
	}

	private void LateUpdate()
	{
		transform.rotation = _cameraRot;
	}

	public void Initialized(int value)
	{
		_maxValue = value;
		_hpSlider.maxValue = _maxValue;
		gameObject.SetActive(false);
	}

	public void UpdateData(int value)
	{
		gameObject.SetActive(true);
		_text.text = $"{value} / {_maxValue}";
        _hpSlider.value = value;
	}
}
