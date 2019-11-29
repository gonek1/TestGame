/**************************************************************************************************/
/** 	© 2017 NULLcode Studio. License: https://creativecommons.org/publicdomain/zero/1.0/deed.ru
/** 	Разработано в рамках проекта: http://null-code.ru/
/**                       ******   Внимание! Проекту нужна Ваша помощь!   ******
/** 	WebMoney: R209469863836, Z126797238132, E274925448496, U157628274347
/** 	Яндекс.Деньги: 410011769316504
/**************************************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitsPool : MonoBehaviour {

	[SerializeField] private HitsComponent sample; // шаблон UI Text
	[SerializeField] private int objectCount = 50; // сколько копий создать (т.е. сколько может быть одновременно объектов на экране)

	void Awake()
	{
		if(Hits.Sample.Length > 0) return;
		sample.gameObject.SetActive(false);
		List<HitsComponent> list = new List<HitsComponent>();
		for(int i = 0; i < objectCount; i++)
		{
			HitsComponent clone = Instantiate(sample) as HitsComponent;
			clone.getTransform.SetParent(this.transform);
			clone.getTransform.localScale = Vector3.one;
			list.Add(clone);
		}
		Hits.SetHitsComponent(list.ToArray());
	}
}
