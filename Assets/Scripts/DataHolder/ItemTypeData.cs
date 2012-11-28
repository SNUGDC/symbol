
using System.Collections;

public class ItemTypeData : BaseLangData
{
	//XML data
	private string filename = "itemtypes";
	
	private static string ITEMTYPES = "itemtypes";
	private static string ITEMTYPE = "itemtype";
	private static string NAME = "name";
	private static string DESCRIPTION = "description";
	private static string ICON = "icon";
	
	public override string GetIconPath() {return "Items/Textures/";}
	
	public ItemTypeData()
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
			sv.Add(XMLHandler.NODE_NAME, ItemTypeData.ITEMTYPES);
			for(int i = 0 ; i < ((string[])name["0"]).Length;i++)
			{
				Hashtable val = new Hashtable();
				ArrayList s = new ArrayList();
				
				val.Add(XMLHandler.NODE_NAME, ItemTypeData.ITEMTYPE);
				val.Add("id", i.ToString());
				
				if(icon[i] != null && "" != icon[i])
				{
					Hashtable ic = new Hashtable();
					ic.Add(XMLHandler.NODE_NAME, ItemTypeData.ICON);
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
					n.Add(XMLHandler.NODE_NAME, ItemTypeData.NAME);
					n.Add("lang", j.ToString());
					n.Add(XMLHandler.CONTENT, text);
					s.Add(n);
					
					Hashtable d = new Hashtable();
					text = ((string[])description[j.ToString()])[i];
					if(text == "")
					{
						text = ((string[])description["0"])[i];
					}
					d.Add(XMLHandler.NODE_NAME, ItemTypeData.DESCRIPTION);
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
	}
	
	public void LoadData()
	{
		ArrayList data = XMLHandler.LoadXML(dir+filename);
		
		if(data.Count > 0)
		{
			foreach(Hashtable entry in data)
			{
				if(entry[XMLHandler.NODE_NAME] as string == ItemTypeData.ITEMTYPES)
				{
					if(entry.ContainsKey(XMLHandler.NODES))
					{
						name = new Hashtable();
						description = new Hashtable();
						string lang = "";
						ArrayList subs = entry[XMLHandler.NODES] as ArrayList;
						icon = new string[subs.Count];
						
						foreach(Hashtable val in subs)
						{
							if(val[XMLHandler.NODE_NAME] as string == ItemTypeData.ITEMTYPE)
							{
								int i = int.Parse((string)val["id"]);
								icon[i]= "";
								
								ArrayList s = val[XMLHandler.NODES] as ArrayList;
								foreach(Hashtable ht in s)
								{
									if(ht[XMLHandler.NODE_NAME] as string == ItemTypeData.NAME)
									{
										lang = ht["lang"] as string;
										if(!name.ContainsKey(lang))
										{
											name[lang] = new string[subs.Count];
										}
										((string[])name[lang])[i] = ht[XMLHandler.CONTENT] as string;
										
									}else if(ht[XMLHandler.NODE_NAME] as string == ItemTypeData.DESCRIPTION)
									{
										lang = ht["lang"] as string;
										if(!description.ContainsKey(lang))
										{
											description[lang] = new string[subs.Count];
										}
										((string[])description[lang])[i] = ht[XMLHandler.CONTENT] as string;
										
									}else if(ht[XMLHandler.NODE_NAME] as string == ItemTypeData.ICON)
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
			
		}
	}
	
	
	
}