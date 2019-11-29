/**************************************************************************************************/
/** 	© 2017 NULLcode Studio. License: https://creativecommons.org/publicdomain/zero/1.0/deed.ru
/** 	Разработано в рамках проекта: http://null-code.ru/
/**                       ******   Внимание! Проекту нужна Ваша помощь!   ******
/** 	WebMoney: R209469863836, Z126797238132, E274925448496, U157628274347
/** 	Яндекс.Деньги: 410011769316504
/**************************************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hits {

	private static HitsComponent[] sample = new HitsComponent[]{};

	public static HitsComponent[] Sample
	{
		get{ return sample; }
	}

	public static void SetHitsComponent(HitsComponent[] arr)
	{
		sample = arr;
	}

	//static bool IsBehind(Vector3 position) // находится ли позиция за камерой
	//{
	//	if(Vector3.Dot(Camera.main.transform.TransformDirection(Vector3.forward), position - Camera.main.transform.position) < 0)
	//	{
	//		return true;
	//	}

	//	return false;
	//}

	public static void AddHit(Vector3 position, float damage, Color color, int fontSize, float lifeTime)
	{
		int j = -1;

		for(int i = 0; i < sample.Length; i++)
		{
			if(!sample[i].isActiveAndEnabled) // поиск не активного элемента
			{
				j = i; // сохраняем id элемента
				break; // выходим
			}
		}

		Color clear = color;
		clear.a = 0;
		sample[j].getText.fontSize = fontSize;
		sample[j].getText.text = damage.ToString();
		sample[j].getTransform.sizeDelta = new Vector2(sample[j].getText.preferredWidth, sample[j].getText.preferredHeight);
		sample[j].getText.color = color;
		sample[j].SetOptions(clear, lifeTime, position);
		sample[j].gameObject.SetActive(true);
	}
}
