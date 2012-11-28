using UnityEngine;
using System.Collections;

public class ItemCategoryData : BaseLangData 
{
	private string filename = "itemcategories";
	
	private static string ITEMCATEGORIES = "itemcategories";
	private static string ITEMCATEGORY = "itemcategory";
	private static string NAME = "name";
	private static string DESCRIPTION = "description";
	private static string ICON = "icon";
	
	public CategoryData[] categorydata = new CategoryData[0];
	public override string GetIconPath() {return "Items/Textures/";}
	
	public ItemCategoryData()
	{
		LoadData();
	}
	public void SaveData()
	{
		if(name != null && name.ContainsKey("0"))
		{
			ArrayList data = new ArrayList();
			ArrayList subs = new ArrayList();
			
			Hashtable sv = new Hashtable();
			sv.Add(XMLHandler.NODE_NAME, ItemCategoryData.ITEMCATEGORIES);
			for(int i = 0 ; i < categorydata.Length;i++)
			{
				Hashtable val = new Hashtable();
				ArrayList s = new ArrayList();
				
				val.Add(XMLHandler.NODE_NAME, ItemCategoryData.ITEMCATEGORY);
				val.Add("id", i.ToString());
				val.Add("type", categorydata[i].type.ToString());
				val.Add("categorynumber", categorydata[i].category_number.ToString());
				
				
				if(icon[i] != null && "" != icon[i])
				{
					Hashtable ic = new Hashtable();
					ic.Add(XMLHandler.NODE_NAME, ItemCategoryData.ICON);
					ic.Add(XMLHandler.CONTENT, icon[i]);
					s.Add(ic);
				}
				for (int j = 0 ; j < name.Count;j++)
				{
					Hashtable n = new Hashtable();
					string text = ((string[])name[j.ToString()])[i];
					if(text == "")
					{
						text = ((string[])name["0"])[i];
					}
					n.Add(XMLHandler.NODE_NAME, ItemCategoryData.NAME);
					n.Add("lang", j.ToString());
					n.Add(XMLHandler.CONTENT, text);
					s.Add(n);
					
					Hashtable d = new Hashtable();
					text = ((string[])description[j.ToString()])[i];
					if(text == "")
					{
						text = ((string[])description["0"])[i];
					}
					d.Add(XMLHandler.NODE_NAME, ItemCategoryData.DESCRIPTION);
					d.Add("lang", j.ToString());
					d.Add(XMLHandler.CONTENT, text);
					s.Add(d);
				}
				val.Add(XMLHandler.NODES,s);
				subs.Add(val);
			}
			sv.Add(XMLHandler.NODES, subs);
			data.Add(sv);
			
			XMLHandler.SaveXML(dir, filename, data);
		}
		/*
		if(name != null && name.ContainsKey("0"))
		{
			ArrayList data = new ArrayList();
			ArrayList subs = new ArrayList();
			Hashtable sv = new Hashtable();
			
			sv.Add(XMLHandler.NODE_NAME, ItemCategoryData.ITEMCATEGORIES);
			for(int i = 0 ; i < categorydata.Length; i++)
			{
				Hashtable it = new Hashtable();
				it.Add(XMLHandler.NODE_NAME, ItemCategoryData.ITEMCATEGORY);
				it.Add("id", i.ToString());
				it.Add("type", categorydata[i].type.ToString());
				it.Add("categorynumber", categorydata[i].category_number.ToString());
				it.Add(XMLHandler.CONTENT, categorydata[i].name);
				it.Add("langcount", name.Count.ToString());
				for (int j = 0 ; j < name.Count;j++)
				{
					
					string text = ((string[])name[j.ToString()])[i];
					if(text == "")
					{
						text = ((string[])name["0"])[i];
					}
					
					it.Add("name"+j.ToString(), text);
					
					
					text = ((string[])description[j.ToString()])[i];
					if(text == "")
					{
						text = ((string[])description["0"])[i];
					}
					
					
					it.Add("description"+j.ToString(), text);
					
				}
				
				
				subs.Add(it);
			}
			sv.Add(XMLHandler.NODES, subs);
			data.Add(sv);
			XMLHandler.SaveXML(dir, filename, data);
		}
		*/
	}
	public void LoadData()
	{
		ArrayList data = XMLHandler.LoadXML(dir+filename);
		
		if(data.Count > 0)
		{
			foreach(Hashtable entry in data)
			{
				if(entry[XMLHandler.NODE_NAME] as string == ItemCategoryData.ITEMCATEGORIES)
				{
					if(entry.ContainsKey(XMLHandler.NODES))
					{
						name = new Hashtable();
						description = new Hashtable();
						string lang = "";
						ArrayList subs = entry[XMLHandler.NODES] as ArrayList;
						icon = new string[subs.Count];
						categorydata = new CategoryData[subs.Count];
						
						foreach(Hashtable val in subs)
						{
							if(val[XMLHandler.NODE_NAME] as string == ItemCategoryData.ITEMCATEGORY)
							{
								int i = int.Parse((string)val["id"]);
								icon[i]= "";
								categorydata[i] = new CategoryData();
								categorydata[i].id = i;
								categorydata[i].type = int.Parse(val["type"] as string);
								categorydata[i].category_number = int.Parse(val["categorynumber"] as string);
								
								
								ArrayList s = val[XMLHandler.NODES] as ArrayList;
								foreach(Hashtable ht in s)
								{
									if(ht[XMLHandler.NODE_NAME] as string == ItemCategoryData.NAME)
									{
										lang = ht["lang"] as string;
										if(!name.ContainsKey(lang))
										{
											name[lang] = new string[subs.Count];
										}
										((string[])name[lang])[i] = ht[XMLHandler.CONTENT] as string;
										
									}else if(ht[XMLHandler.NODE_NAME] as string == ItemCategoryData.DESCRIPTION)
									{
										lang = ht["lang"] as string;
										if(!description.ContainsKey(lang))
										{
											description[lang] = new string[subs.Count];
										}
										((string[])description[lang])[i] = ht[XMLHandler.CONTENT] as string;
										
									}else if(ht[XMLHandler.NODE_NAME] as string == ItemCategoryData.ICON)
									{
										icon[i] = ht[XMLHandler.CONTENT] as string;
									}
									
								}
							}
						}
					}
				}
			}
		}else
		{
			this.AddCategory("New Category", "New Description", DataHolder.Languages().GetDataCount());
		}
		/*
		ArrayList data = XMLHandler.LoadXML(dir+filename);
		
		if(data.Count > 0 )
		{
			foreach(Hashtable entry in data)
			{
				if(entry[XMLHandler.NODE_NAME] as string == ItemCategoryData.ITEMCATEGORIES)
				{
					if(entry.ContainsKey(XMLHandler.NODES))
					{
						name = new Hashtable();
						description = new Hashtable();
						ArrayList subs = entry[XMLHandler.NODES] as ArrayList;
						categorydata = new CategoryData[subs.Count];
						name["0"] = new string[subs.Count];
						description["0"] = new string[subs.Count];
						icon = new string[subs.Count];
						
						foreach(Hashtable it in subs)
						{
							if(it[XMLHandler.NODE_NAME] as string == ItemCategoryData.ITEMCATEGORY)
							{
								int i = int.Parse(it["id"] as string);
								
								categorydata[i] = new CategoryData();
								categorydata[i].id = i;
								categorydata[i].type = int.Parse(it["type"] as string);
								categorydata[i].category_number = int.Parse(it["categorynumber"] as string);
								categorydata[i].name = it[XMLHandler.CONTENT] as string;
								
								int langcount = int.Parse(it["langcount"] as string);
								
								for(int j = 0 ; j < langcount; j++)
								{
									
									name[j.ToString()] = new string[langcount];
									description[j.ToString()] = new string[langcount];
									((string[])name[j.ToString()])[i] = it["name"+j.ToString()] as string;
									((string[])description[j.ToString()])[i] = it["description"+j.ToString()] as string;
								}
								this.icon[i] = "";
							}
						}
					}else
					{
						Debug.LogError("entry.ContainsKey(XMLHandler.NODES) is null");
					}
					
					
				}
			}
		}else
		{
			this.AddCategory("New Category", "New Description", DataHolder.Languages().GetDataCount());
		}
		*/
		
	}
	
	public void AddCategory(string n , string d, int count)
	{
		base.AddBaseData(n,d,count);
		
		categorydata = ArrayHelper.Add(new CategoryData(), this.categorydata);
	}
	public override void RemoveData(int index)
	{
		base.RemoveData(index);
		
		categorydata = ArrayHelper.Remove(index, this.categorydata);
	}
	
	public override void Copy(int index)
	{
		base.Copy(index);
		categorydata = ArrayHelper.Add(new CategoryData(), this.categorydata);
		
		categorydata[categorydata.Length-1].id = categorydata[index].id;
		categorydata[categorydata.Length-1].type = categorydata[index].type;
		categorydata[categorydata.Length-1].name = categorydata[index].name;
		categorydata[categorydata.Length-1].category_number = categorydata[index].category_number;
	}
	
	public void RemoveCategory(int index)
	{
		
	}
	
	
}

public class CategoryData
{
	public int id;
	public int type;
	public int category_number;
	public string name;
	
	public CategoryData()
	{
		this.id  = 0;
		this.type = 0;
		this.category_number = 0;
		this.name = "New Category";
	}
}
