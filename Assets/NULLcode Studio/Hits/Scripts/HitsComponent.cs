using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class HitsComponent : MonoBehaviour {
    
	[SerializeField] private float speed = 100; // скорость движения текста
	[SerializeField] private Text _Text;
	[SerializeField] private RectTransform _RectTransform;
    Camera camera;
	private float lifeTime;
	private Vector3 hitPosition;
	private float curTime;
	private Color clear;
	private Vector2 upPosition;

	public RectTransform getTransform
	{
		get{ return _RectTransform; }
	}
	
	public Text getText
	{
		get{ return _Text; }
	}

	public void SetOptions(Color clearColor, float time, Vector3 hitPos)
	{
        camera = FindObjectOfType<Camera>();
		clear = clearColor;
		lifeTime = time;
		hitPosition = hitPos;
	}

	void LateUpdate() // анимация текста
	{
		Vector2 curPosition = camera.WorldToScreenPoint(hitPosition);
		upPosition += Vector2.up * speed * Time.deltaTime;
		clear.a = 1 - curTime/lifeTime;
		_Text.color = clear;
		_RectTransform.anchoredPosition = curPosition + upPosition + new Vector2(400,100);
		curTime += Time.deltaTime;
		if(curTime > lifeTime)
		{
			_RectTransform.anchoredPosition = Vector2.zero;
			upPosition = Vector2.zero;
			curTime = 0;
			gameObject.SetActive(false);
		}
	}
}
