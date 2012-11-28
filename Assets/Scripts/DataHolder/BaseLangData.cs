using UnityEngine;
using System.Collections;

//written by seyoung.chu
public class BaseLangData
{
	public Hashtable name;
	public Hashtable description;
	public string[] icon = new string[0];
	
	public string skinPath = "HUD/";
	
	protected string dir = "Configs/";
	
	public BaseLangData()
	{
	}
	public int GetDataCount()
	{
		int val =  0;
		if(name != null && name.ContainsKey("0"))
		{
			val = ((string[])name["0"]).Length;
		}
		return val;
	}
	
	public string GetName(int index, int lang)
	{
		string n ="";
		if(index < ((string[])name[lang.ToString()]).Length)
		{
			n = ((string[])name[lang.ToString()])[index];
		}
		return n;
	}
	
	public string GetName(int index)
	{
		//temporary code~
		//return this.GetName(index, GameStateHandler.GetLanguage());
		return this.GetName(index, 0); 
	}
	
	public string GetDescription(int index, int lang)
	{
		string n = "";
		if(index <((string[])description[lang.ToString()]).Length)
		{
			n = ((string[])description[lang.ToString()])[index];
		}
		return n;
	}
	
	public string GetDescription(int index)
	{
		//temporaty code~ should be edit this
		//return this.GetName(index , GameStateHandler.GetLanguate());
		return this.GetName(index, 0);
	}
	
	public virtual string GetIconPath() { return "";}
	
	public Texture2D GetIcon(int index)
	{
		Texture2D tex = null;
		if(this.icon[index] != null && "" != this.icon[index])
		{
			tex = (Texture2D)Resources.Load(this.GetIconPath()+this.icon[index], typeof(Texture2D));
		}
		return tex;
	}
	
	public GUIContent GetContent(int index)
	{
		return new GUIContent(this.GetName(index), this.GetIcon(index));
	}
	
	public string[] GetNameList(bool showIDs)
	{
		string[] result = new string[0];
		if(name != null)
		{
			result = new string[((string[])name["0"]).Length];
			for(var i  = 0 ; i < ((string[])name["0"]).Length;i++)
			{
				if(showIDs)
				{
					result[i] = i.ToString() + ": " + ((string[])name["0"])[i];
				}else
				{
					result[i] = ((string[])name["0"])[i];
				}
			}
		}
		return result;
	}
	
	public void AddBaseData(string n , string d, int count)
	{
		if(name == null)
		{
			name = new Hashtable();
			description = new Hashtable();
			for(int i = 0 ; i < count; i++)
			{
				name.Add(i.ToString(), new string[]{n});
				description.Add(i.ToString(), new string[] {d});
			}
		}
		else
		{
			for(int i = 0 ; i< count; i++)
			{
				name[i.ToString()] = ArrayHelper.Add(n, name[i.ToString()] as string[]);
				description[i.ToString()] = ArrayHelper.Add(d, description[i.ToString()] as string[]);
			}
		}
		icon = ArrayHelper.Add("", icon);
	}
	
	public virtual void RemoveData(int index)
	{
		for(int i = 0 ; i < name.Count; i++)
		{
			name[i.ToString()] = ArrayHelper.Remove(index,name[i.ToString()] as string[]);
			description[i.ToString()] = ArrayHelper.Remove(index, description[i.ToString()] as string[]);
		}
		icon = ArrayHelper.Remove(index, icon);
	}
	
	public virtual void Copy(int index)
	{
		for(int i = 0 ; i < name.Count; i++)
		{
			name[i.ToString()] = ArrayHelper.Add(((string[])name[i.ToString()])[index], name[i.ToString()] as string[]);
			description[i.ToString()] = ArrayHelper.Add(((string[])description[i.ToString()])[index], description[i.ToString()] as string[]);
			
		}
		icon = ArrayHelper.Add(icon[index], icon);
	}
	
	public void AddLanguage(int lang)
	{
		if(name != null)
		{
			name[lang.ToString()] = new string[((string[])name["0"]).Length];
			System.Array.Copy(((string[])name["0"]), ((string[])name[lang.ToString()]),((string[])name["0"]).Length);
			description[lang.ToString()] = new string[((string[])description["0"]).Length];
			System.Array.Copy(((string[])description["0"]), ((string[])description[lang.ToString()]),((string[])description["0"]).Length);
			
		}
	}
	public void RemoveLanguage(int lang)
	{
		if(name != null)
		{
			for(int i = 0 ; i < name.Count-1; i++)
			{
				name[i.ToString()] = name[(i+1).ToString()];
				description[i.ToString()] = description[(i+1).ToString()];
			}
			name.Remove((name.Count-1).ToString());
			description.Remove((description.Count-1).ToString());
		}
	}
	
	public int CheckForIndex(int index, int check)
	{
		if(check == index) check = 0;
		else if(check > index) check -= 1;
		return check;
	}
	
}

