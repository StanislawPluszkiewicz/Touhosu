using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class DestroyWhenNoChilds : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
        
		}

		// Update is called once per frame
		void Update()
		{
			if (transform.childCount == 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
