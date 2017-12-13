
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions{
	public static IList<T> Shuffle<T> (this IList<T> list){
		int n = list.Count;
		while(n > 1){
			n--;
			int k = Random.Range (0, n + 1);
			T valor = list [k];
			list [k] = list[n];
			list [n] = valor;
		}
		return list;
	}
}
