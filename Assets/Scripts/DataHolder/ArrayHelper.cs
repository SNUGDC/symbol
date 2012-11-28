
using System;
using System.Collections;
using UnityEngine;

//written by seyoung.chu
public class ArrayHelper 
{	
	//base types
	public static string[] Add(string n , string[] list)
	{
		ArrayList tmp = new ArrayList();
		foreach(string str in list) tmp.Add(str);
		tmp.Add(n);
		return tmp.ToArray(typeof(string)) as string[];
	}
	
	public static string[] Remove(int index, string[] list)
	{
		ArrayList tmp = new ArrayList();
		foreach(string str in list) tmp.Add(str);
		tmp.RemoveAt(index);
		return tmp.ToArray(typeof(string)) as string[];
	}
	
	public static CategoryData[] Add(CategoryData n, CategoryData[] list)
	{
		ArrayList tmp = new ArrayList();
		foreach(CategoryData str in list) tmp.Add(str);
		tmp.Add(n);
		return tmp.ToArray(typeof(CategoryData)) as CategoryData[];
	}
	public static CategoryData[] Remove(int index, CategoryData[] list)
	{
		ArrayList tmp = new ArrayList();
		foreach(CategoryData str in list) tmp.Add(str);
		tmp.RemoveAt(index);
		return tmp.ToArray(typeof(CategoryData)) as CategoryData[];
	}
	
	public static Item[] Add(Item n, Item[] list)
	{
		ArrayList tmp = new ArrayList();
		foreach(Item str in list) tmp.Add(str);
		tmp.Add(n);
		return tmp.ToArray(typeof(Item)) as Item[];
	}
	
	public static Item[] Remove(int index, Item[] list)
	{
		ArrayList tmp = new ArrayList();
		foreach(Item str in list) tmp.Add(str);
		tmp.RemoveAt(index);
		return tmp.ToArray(typeof(Item)) as Item[];
	}
	
	
}

