# Unity UI-Stack-System

Unity UI-Stack-System是一个基于UGUI的UI栈管理系统，本项目由鳍片环流室 Fin TOKMAK开发组开发，使用此包请遵守相关许可。

使用此系统可以快速建立一个UI Stack并且将场景中复杂的UI层级关系通过栈进行组织。

除此之外，栈内的每一层UI Panel都可以对栈操作进行响应。基于这一特性，开发者可以让UI Panel在保持执行逻辑代码的前提下隐藏在后台，从而实现非常复杂的UI逻辑开发。

![ui_stack_system_demo_1](https://user-images.githubusercontent.com/79500078/124216225-51a6e900-db28-11eb-8897-ce11543885de.gif)

# 下载

## 依赖项

在使用本框架之前，您需要安装本项目的依赖包，包括：
`com.dbrizov.naughtyattributes`
`com.serializabledictionary`
`net.wraithavengames.unityinterfacesupport`
`com.unity.inputsystem`

您可以直接将以下内容复制到项目包文件管理器的`manifest.json`中以快速导入所有依赖项

```
"com.dbrizov.naughtyattributes": "https://github.com/dbrizov/NaughtyAttributes.git#upm",
"com.serializabledictionary": "https://github.com/Fangjun-Zhou/Unity-SerializableDictionary.git#upm-serializabledictionary",
"net.wraithavengames.unityinterfacesupport": "https://github.com/TheDudeFromCI/Unity-Interface-Support.git?path=/Packages/net.wraithavengames.unityinterfacesupport",
"com.unity.inputsystem": "1.1.0-pre.5",
```

## 安装

安装Unity UI-Stack-System可以在package manager中直接添加`https://github.com/Fangjun-Zhou/Unity-UI-Stack-System.git#upm-uistacksystem`

或是将以下内容复制到项目包文件管理器的`manifest.json`中

```
"com.fintokmak.uistacksystem": "https://github.com/Fangjun-Zhou/Unity-UI-Stack-System.git#upm-uistacksystem"
```

# 文档

Unity UI-Stack-System的使用文档请看[这里](https://fangjun-zhou.github.io/Unity-UI-Stack-System/)

# 使用

## UI Panel Element

所有需要被UI Stack接管的Panel都需要挂载UIPanelElement

### Panel事件

UIPanelElement中除了包含一个对调用自身的UI Stack Manager（后文中会介绍）的引用和一个Panel name字段，还有六个UI Stack操作的回调函数及对应的Unity Event。

这六个事件分别是`OnPush`, `OnPop`, `OnFinishPop`, `OnPause`, `OnFinishPause`, `OnResume`。

后文中还会详细介绍这六个关键事件的意义和生命周期中调用他们的过程

### UIFinishListeners

UIPanelElement中有一个UIStackEventListener列表字段

这个列表中储存了一系列UIStackEventInvoker。这些Invoker需要被挂载到具有退出动画的UI对象上，在完成动画时，UI对象需要通过脚本或者AnimationEvent（如果你没有使用DOTween）调用EventInvoker中的完成事件。

UIPanelElement会在列表中的所有UI完成退出动画后才释放挂起状态，这一逻辑也会在后文中介绍。

### 示例

通过Unity Event SetActive面板

![image](https://user-images.githubusercontent.com/79500078/124213844-de9b7380-db23-11eb-9cf2-3b9574dcb618.png)

通过事件监听机制触发和释放栈操作挂起状态

![image](https://user-images.githubusercontent.com/79500078/124214522-eb6c9700-db24-11eb-8894-9f7d91d43717.png)

## UI Panel Child

处于任意UI Panel内的逻辑都需要继承自UIPanelChild基类。

这个类提供了对父Panel的引用和基础的Panel合法性校验功能

### 示例

```c#
public class SettingsButtonController : UIPanelChild
{
    #region Public Field

    [BoxGroup("Panel References")]
    [ValidateInput("IsPanelValid", "The panel is not in the UIPanels in panelRootManager.")]
    public UIPanelElement settingsPanel;

    #endregion

    #region Public Methods

    /// <summary>
    /// Call this method to open the settings panel in the UI Stack Manager
    /// </summary>
    public void OpenSettingsPanel()
    {
        rootPanel.panelRootManager.Push(settingsPanel);
    }

    #endregion
}
```

![image](https://user-images.githubusercontent.com/79500078/124214608-13f49100-db25-11eb-8f07-3aa242409767.png)

## UI Stack Manager

![image](https://user-images.githubusercontent.com/79500078/124214644-2078e980-db25-11eb-90a9-f0fd51f52381.png)

UIStackManager是UI Stack System的核心组件，这个组件通过一个StackADT对其所有子面板进行管理。

其中，UIStackManage所有可调用的UIPanelElement以<UIPanelElement, string>字典的形式储存在UIPanels中。Key是对应的UIPanelElement，Value是Panel name。

HasInitializePanel控制UI Stack Manager的初始化Panel。当取消勾选时，场景载入时将不会有Panel被压入UI Stack。

InitializationPanel是初始化压入的Panel，此Panel必须处于UIPanels中才可以被调用

## UI Stack Event Invoker

所有涉及到退出动画的UI都需要挂载UIStackEventInvoker.

UIStackEventInvoker中的Finish函数需要在动画完成的时候调用。Panel通过对所有Invoker的监听，可以在最后一个动画播放完成后完成等待挂起并退出。

### 示例

```c#
public class UIStackEventInvoker : MonoBehaviour, IUIStackEventInvoker
{
    public Action finishAction { get; set; }

    #region Public Methods

    /// <summary>
    /// Call this method when teh UI finished animation or logic
    /// </summary>
    public void Finish()
    {
        finishAction?.Invoke();
    }

    #endregion
}
```

挂载Invoker的UI

![image](https://user-images.githubusercontent.com/79500078/124215027-d80dfb80-db25-11eb-8327-8aae42d401ce.png)

通过动画事件调用

![image](https://user-images.githubusercontent.com/79500078/124215107-fd9b0500-db25-11eb-9efe-a80b17d1d1ac.png)

![image](https://user-images.githubusercontent.com/79500078/124215152-13102f00-db26-11eb-8808-f2fe8e3782e8.png)

## UI Stack 生命周期

[UI Stack System生命周期.pdf](https://github.com/Fangjun-Zhou/Unity-UI-Stack-System/files/6751850/UI.Stack.System.pdf)

