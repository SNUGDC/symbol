using UnityEngine;
using System.Collections;
//written by seyoung.chu
public class ItemData : BaseLangData
{
	public Item[] item = new Item[0];
	
	public ItemData()
	{
		LoadData();
	}
	
	// XML data 
	private string filename = "items";
	
	private static string ITEMS = "items";
	private static string ITEM = "item";
	
	private static string NAME = "name";
	private static string DESCRIPTION = "description";
	private static string ICON = "icon";
	
	public override string GetIconPath() {return "Items/Textures/";}
	public string GetPrefabPath() { return "Items/Prefabs/";}
	
	public void LoadData()
	{
		string lang = "";
		ArrayList data = XMLHandler.LoadXML(dir+filename);
		
		if(data.Count > 0)
		{
			foreach(Hashtable entry in data)
			{
				if(entry[XMLHandler.NODE_NAME] as string == ItemData.ITEMS)
				{
					if(entry.ContainsKey(XMLHandler.NODES))
					{
						name = new Hashtable();
						description = new Hashtable();
						ArrayList subs = entry[XMLHandler.NODES] as ArrayList;
						icon = new string[subs.Count];
						item = new Item[subs.Count];
						name["0"] = new string[subs.Count];
						description["0"] = new string[subs.Count];
						
						foreach(Hashtable it in subs)
						{
							if(it[XMLHandler.NODE_NAME] as string == ItemData.ITEM)
							{
								int i  = int.Parse((string)it["id"]) - 1;
								icon[i] = "";
								item[i] = new Item();
								item[i].id = i + 1;
								item[i].name = it["name"] as string; 
								
								((string[])name["0"])[i] = item[i].name;
								
								item[i].category = int.Parse((string)it["category"]);
								item[i].own = int.Parse((string)it["own"]);
								item[i].prefabName = it["prefabname"] as string;
								item[i].itemType = int.Parse((string)it["itemtype"]);
								item[i].bill = int.Parse((string)it["bill"]);
								item[i].buyPrice = int.Parse((string)it["buyprice"]);
								item[i].sellable = int.Parse((string)it["sellable"]);
								item[i].sellPrice = int.Parse((string)it["sellprice"]);
								item[i].removable = int.Parse((string)it["removable"]);
								item[i].canTrade = int.Parse((string)it["cantrade"]);
								item[i].canMerge = int.Parse((string)it["canmerge"]);
								item[i].maxMerge = int.Parse((string)it["maxmerge"]);
								item[i].period = int.Parse((string)it["period"]);
								item[i].consume = int.Parse((string)it["consume"]);
								item[i].iconMark = int.Parse((string)it["iconmark"]);
								item[i].shopReg = int.Parse((string)it["shopreg"]);
								item[i].iconFile = it[XMLHandler.CONTENT] as string;
								ArrayList s = it[XMLHandler.NODES] as ArrayList;
								foreach(Hashtable ht in s)
								{
									if(ht[XMLHandler.NODE_NAME] as string == ItemData.NAME)
									{
										lang = ht["lang"] as string;
										if(!name.ContainsKey(lang))
										{
											name[lang] = new string[subs.Count];
										}
										((string[])name[lang])[i] = ht[XMLHandler.CONTENT] as string;
										
									}else if(ht[XMLHandler.NODE_NAME] as string == ItemData.DESCRIPTION)
									{
										lang = ht["lang"] as string;
										if(!description.ContainsKey(lang))
										{
											description[lang] = new string[subs.Count];
										}
										((string[])description[lang])[i] = ht[XMLHandler.CONTENT] as string;
										
									}else if(ht[XMLHandler.NODE_NAME] as string == ItemData.ICON)
									{
										icon[i] = ht[XMLHandler.CONTENT] as string;
									}
									
								}
								
								//this.icon[i] = it[XMLHandler.CONTENT] as string;

							}
						}
					}
				}
			}
		}else
		{
			Debug.Log("items data file empty or cant read items data file");
		}
		
	}
	
	public void SaveData()
	{
		ArrayList data = new ArrayList();
		ArrayList subs = new ArrayList();
		Hashtable sv = new Hashtable();
		
		sv.Add(XMLHandler.NODE_NAME, ItemData.ITEMS);
		
		for(int i = 0 ; i < item.Length ; i++)
		{
			ArrayList s = new ArrayList();
			
			Hashtable it = new Hashtable();
			it.Add(XMLHandler.NODE_NAME, ItemData.ITEM);
			int id = i + 1; // The ID,0 is null item
			it.Add("id", id.ToString());
			//it.Add("name", item[i].name);
			it.Add("name",((string[])name["0"])[i]);
			
			it.Add("category", item[i].category.ToString());
			it.Add("own", item[i].own.ToString());
			it.Add("prefabname", item[i].prefabName);
			it.Add("itemtype", item[i].itemType.ToString());
			it.Add("bill", item[i].bill.ToString());
			it.Add("buyprice", item[i].buyPrice.ToString());
			it.Add("sellable", item[i].sellable.ToString());
			it.Add("sellprice", item[i].sellPrice.ToString());
			it.Add("removable", item[i].removable.ToString());
			it.Add("cantrade", item[i].canTrade.ToString());
			it.Add("canmerge", item[i].canMerge.ToString());
			it.Add("maxmerge", item[i].maxMerge.ToString());
			it.Add("period", item[i].period.ToString());
			it.Add("consume", item[i].consume.ToString());
			it.Add("iconmark", item[i].iconMark.ToString());
			it.Add("shopreg", item[i].shopReg.ToString());
			
				for (int j = 0 ; j < name.Count;j++)
				{
					Hashtable n = new Hashtable();
					string text = ((string[])name[j.ToString()])[i];
					if(text == "")
					{
						text = ((string[])name["0"])[i];
					}
					n.Add(XMLHandler.NODE_NAME, ItemData.NAME);
					n.Add("lang", j.ToString());
					n.Add(XMLHandler.CONTENT, text);
					s.Add(n);
					
					Hashtable d = new Hashtable();
					text = ((string[])description[j.ToString()])[i];
					if(text == "")
					{
						text = ((string[])description["0"])[i];
					}
					d.Add(XMLHandler.NODE_NAME, ItemData.DESCRIPTION);
					d.Add("lang", j.ToString());
					d.Add(XMLHandler.CONTENT, text);
					s.Add(d);
				}
			
			//it.Add(XMLHandler.CONTENT, icon[i]);
			it.Add(XMLHandler.NODES,s);
			subs.Add(it);
		}
		sv.Add(XMLHandler.NODES, subs);
		
		data.Add(sv);
		XMLHandler.SaveXML(dir, filename, data);
	}
	
	public void AddItem(string n , string d , int count)
	{
		base.AddBaseData(n, d, count);
		item = ArrayHelper.Add(new Item(), item);
		
		
		
	}
	
	public override void RemoveData(int index)
	{
		base.RemoveData(index);
		item = ArrayHelper.Remove(index,item);
		
		
	}
	
	public override void Copy(int index)
	{
		base.Copy(index);
		item = ArrayHelper.Add(new Item(), item);
		
		item[item.Length-1].itemType = item[index].itemType;
		item[item.Length-1].id = item[index].id;
		item[item.Length-1].name = item[index].name;
		item[item.Length-1].category = item[index].category;
		item[item.Length-1].own = item[index].own;
		item[item.Length-1].prefabName = item[index].prefabName;
		item[item.Length-1].bill = item[index].bill;
		item[item.Length-1].buyPrice = item[index].buyPrice;
		item[item.Length-1].sellable = item[index].sellable;
		item[item.Length-1].sellPrice = item[index].sellPrice;
		item[item.Length-1].removable = item[index].removable;
		item[item.Length-1].canTrade = item[index].canTrade;
		item[item.Length-1].canMerge = item[index].canMerge;
		item[item.Length-1].maxMerge = item[index].maxMerge;
		item[item.Length-1].period = item[index].period;
		item[item.Length-1].consume = item[index].consume;
		item[item.Length-1].iconMark = item[index].iconMark;
		item[item.Length-1].shopReg = item[index].shopReg;
		item[item.Length-1].iconFile = item[index].iconFile;
		
	}
	
	public void RemoveItemType(int index)
	{
		for(int i = 0 ; i < item.Length; i++)
		{
			if(item[i].itemType == index)
			{
				item[i].itemType = 0;
			}else if(item[i].itemType > index)
			{
				item[i].itemType -= 1;
			}
		}
	}
	
	public string GetItemTextureName(int type, int category, int index)
	{
		Item[] tmp = this.GetItemList(type,category);
		if(tmp.Length == 0 || index >= tmp.Length)
		{
			return "NoImage";
		}
		if(tmp[index] == null)
		{
			return "NoImage";
		}
		return tmp[index].iconFile;
	}
	
	public string GetItemName(int type, int category, int index)
	{
		Item[] tmp = this.GetItemList(type,category);
		if(tmp.Length == 0 || index >= tmp.Length)
		{
			//Debug.Log("Cant find name index : "+ index + " length : " + tmp.Length+ " type : " + type + " category : " + category);
			return "No Name";
		}
		if(tmp[index] == null)
		{
			//Debug.Log("cant find name , no data");
			return "No Name";
		}
		return tmp[index].name;
	}
	
	public string GetItemPrice(int type, int category, int index)
	{
		Item[] tmp = this.GetItemList(type,category);
		if(tmp.Length == 0 || index >= tmp.Length)
		{
			
			return "Free";
		}
		if(tmp[index] == null)
		{
			
			return "Free";
		}
		return tmp[index].buyPrice.ToString();
	}
	
	public string GetItemSex(int type, int category, int index)
	{
		Item[] tmp = this.GetItemList(type,category);
		if(tmp.Length == 0 || index >= tmp.Length)
		{
			
			return "Unisex";
		}
		if(tmp[index] == null)
		{
			
			return "Unisex";
		}
		
		//test code 
		//return tmp[index].sex.ToString();
		return "Male";
	}
	/*
	public string GetItemLevel(int type, int category, int index)
	{
		Item[] tmp = this.GetItemList(type,category);
		if(tmp.Length == 0 || index >= tmp.Length)
		{
			
			return "Lv.0";
		}
		if(tmp[index] == null)
		{
			
			return "Lv.0";
		}
		
		
		//test code 
		//string str = tmp[index].level.ToString();
		//return "Lv."+str;
		return "Lv.1";
	}
	
	*/
	
	
	
	
	public Item[] GetItemList(int type, int category)
	{
		ArrayList tmp = new ArrayList();
		foreach(Item val in item)
		{
			if(val.category == category && val.itemType == type)
			{
				tmp.Add(val);
			}
		}
		//Debug.Log(tmp.Count + "found item list " + category + " category " + type + "type");
		return tmp.ToArray(typeof(Item)) as Item[];
	}
}


public class Item 
{
	public int id = -1; // index 1~ 500000
	public string name = ""; // item name
	public int category = 0; // 
	public int own = 0; // period : infinity 0, limit 1
	public string prefabName = "";
	public int itemType = 0; // type : null 0,kart 1,character 2, kart parts 3,collections 4,power up 5
	public int bill = 0; // bill method : coins 0  , cash 1
	public int buyPrice = 0; // price : 0 ~ 100000000
	public int sellable = 0; // sellable : sellable 0 , unsellable 1
	public int sellPrice = 50; // sell price : 0 ~ 100000000
	public int removable = 0; // removable : removable 0 , unremovable 1
	public int canTrade = 0; // trade : Can Trade item 0 , Can't Trade item 1
	public int canMerge = 0; // Merge : Can Merge item 0 , Can't Merge item 1
	public int maxMerge = 0; // MaxMerge Limit Count 0 ~ 99
	public int period = 0; //if own == 1 else period time
	public int consume = 0; //consumable : Consumable 0 , UnConsumable 1
	public int iconMark = 0; // special icon mark : null is 0 , new is 1, now sale! is 2, Event is 3
	public int shopReg = 0; // Shop Register : Buyable 0 , Unbuyable 1
	public string iconFile = ""; // item icon file name
	
	
	public Item()
	{
	}
	
	public GameObject GetPrefabInstance()
	{
		GameObject prefab = null;
		if("" != this.prefabName)
		{
			GameObject tmp = (GameObject)Resources.Load(DataHolder.Items().GetPrefabPath()+this.prefabName, typeof(GameObject));
			if(tmp) prefab = (GameObject)GameObject.Instantiate(tmp);
		}
		return prefab;
	}
}
