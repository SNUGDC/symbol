
using UnityEngine;

public class DataHolder
{
	private static DataHolder instance;
	
	//language data 
	public LanguageData languages;
	//ItemType data
	public ItemTypeData itemtype;
	//ItemCategory data
	public ItemCategoryData itemcategory;
	//Item data
	public ItemData items;
	
	
	private DataHolder()
	{
		if(instance != null)
		{
			Debug.Log("There is already an instance of DataHolder!");
			return;
		}
		instance = this;
		Init();
	}
	
	public void Init()
	{
		languages = new LanguageData();
		itemtype = new ItemTypeData();
		itemcategory = new ItemCategoryData();
		items = new ItemData();
		
	}
	
	public static DataHolder Instance()
	{
		if(instance == null)
		{
			new DataHolder();
		}
		return instance;
	}
	
	public static LanguageData Languages()
	{
		return DataHolder.Instance().languages;
	}
	
	public static string Language(int index)
	{
		return DataHolder.Instance().languages.GetName(index);
	}
	//itemtype
	public static ItemTypeData ItemTypeData()
	{
		return DataHolder.Instance().itemtype;
	}
	
	public static string ItemType(int index)
	{
		return DataHolder.Instance().itemtype.GetName(index);
	}
	//category
	public static ItemCategoryData ItemCategories()
	{
		return DataHolder.Instance().itemcategory;
	}
	
	public static CategoryData ItemCategory(int index)
	{
		return DataHolder.Instance().itemcategory.categorydata[index];
	}
	//item
	public static ItemData Items()
	{
		return DataHolder.Instance().items;
	}
	
	public static Item Item(int index)
	{
		return DataHolder.Instance().items.item[index];
	}
}

