using UnityEngine;
using System.Collections;
using System;

public enum WindowType
{
    normal,//默认打开窗口，全屏，关闭时调用上一个窗口的show方法
    popNormal,//弹窗（非全屏）,点击非窗口时会关闭当前弹窗
    popNotClose,//弹窗，点击非窗口时不会关闭当前弹窗

}

public class aa
{

}
public class BaseWindow : MonoBehaviour {

    /// <summary>
    /// 窗口显示由windowsManager调用自动实现注册
    /// </summary>
    protected virtual void Init()
    {

    }

    /// <summary>
    /// 窗口显示
    /// </summary>
	protected virtual void Show()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 窗口隐藏
    /// </summary>
    protected virtual void Hide()
    {
        gameObject.SetActive(true);


      
        Receive("tt","aa","bb",11);
    }

    /// <summary>
    /// 接受消息处理
    /// </summary>
    /// <param name="type">处理的消息类型</param>
    /// <param name="obj"></param>
    protected virtual void Receive(string type,params System.Object[] obj)
    {
        
    }
    /// <summary>
    /// 从当前窗口栈中移除本窗口脱离windowsManager管理
    /// </summary>
    public virtual void Remove()
    {

    }

}
