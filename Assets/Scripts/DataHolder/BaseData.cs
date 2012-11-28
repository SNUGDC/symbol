using UnityEngine;
//written by seyoung.chu
public class BaseData
{
	public string[] name;
	public string skinPath = "HUD/";
	
	protected string dir = "Configs/";
	
	public BaseData()
	{
	}
	
	public int GetDataCount()
	{
		int val  = 0;
		if(name != null)
		{
			val = name.Length;
		}
		return val;
	}
	
	public string GetName(int index)
	{
		return name[index];
	}
	
	public string[] GetNameList(bool showIDs)
	{
		string[] result = new string[0];
		if(name != null)
		{
			result = new string[name.Length];
			for(int i = 0 ; i < name.Length; i++)
			{
				if(showIDs)
				{
					result[i] = i.ToString() + ": " + name[i];
				}else
				{
					result[i] = name[i];
				}
			}
		}
		return result;
	}
	
	public virtual void RemoveData(int index)
	{
	}
	
	public virtual void Copy(int index)
	{
	}
	
	
}

public class ChoiceContent
{
	public GUIContent content;
	public bool active = true;
	public string info ="";
	
	public ChoiceContent(string text) : this(new GUIContent(text))
	{
	}
	public ChoiceContent(GUIContent c) : this(c, true)
	{
	}
	public ChoiceContent(GUIContent c , bool a) : this(c,a,"")
	{
		
	}
	
	public ChoiceContent(GUIContent c , bool a , string i)
	{
		this.content = c;
		this.active = a;
		this.info = i;
	}
}

