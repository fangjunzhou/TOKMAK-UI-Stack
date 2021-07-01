# Unity UI-Stack-System

Unity UI-Stack-System是一个基于UGUI的UI栈管理系统，本项目由鳍片环流室 Fin TOKMAK开发组开发，使用此包请遵守相关许可。

使用此系统可以快速建立一个UI Stack并且将场景中复杂的UI层级关系通过栈进行组织。

除此之外，栈内的每一层UI Panel都可以对栈操作进行响应。基于这一特性，开发者可以让UI Panel在保持执行逻辑代码的前提下隐藏在后台，从而实现非常复杂的UI逻辑开发。

# 下载

## 依赖项

在使用本框架之前，您需要安装本项目的依赖包，包括：
`com.dbrizov.naughtyattributes`
`com.serializabledictionary`
`com.unity.inputsystem`

您可以直接将以下内容复制到项目包文件管理器的`manifest.json`中以快速导入所有依赖项

```
"com.dbrizov.naughtyattributes": "https://github.com/dbrizov/NaughtyAttributes.git#upm",
"com.serializabledictionary": "https://github.com/Fangjun-Zhou/Unity-SerializableDictionary.git#upm-serializabledictionary",
"com.unity.inputsystem": "1.1.0-pre.5",
```

## 安装

安装Unity UI-Stack-System可以在package manager中直接添加`https://github.com/Fangjun-Zhou/Unity-UI-Stack-System.git#upm-uistacksystem`

或是将以下内容复制到项目包文件管理器的`manifest.json`中

```
"com.fintokmak.uistacksystem": "https://github.com/Fangjun-Zhou/Unity-UI-Stack-System.git#upm-uistacksystem"
```

# 使用

## UI Panel Element

UIPanelElement是一个继承自MonoBehavior的子类，也是整个UI Stack System中所有stack-based UI需要继承的基类。

这个类中除了包含一个对调用自身的UI Stack Manager（后文中会介绍）的引用和一个Panel name字段，还有四个UI Stack操作的回调函数。

这四个函数分别是`OnPush`, `OnPop`, `OnPause`, `OnResume`。

后文中还会详细介绍这四个关键函数的意义和生命周期中调用他们的过程

除此之外，UIPanelElement基类还提供了四个对应的UnityEvent在对应的生命周期中被调用。

### 示例
```c#
public class SampleMainPanelElement : UIPanelElement
{
    #region UIPanelElement Callback

    public override void OnPush()
    {
        // Activate self
        gameObject.SetActive(true);

        base.OnPush();
    }

    public override void OnPop()
    {
        base.OnPop();

        // Deactivate self
        gameObject.SetActive(false);
    }

    public override void OnPause()
    {
        base.OnPause();

        // Deactivate self
        gameObject.SetActive(false);
    }

    public override void OnResume()
    {
        // Activate self
        gameObject.SetActive(true);

        base.OnResume();
    }

    #endregion
}
```

![image](https://user-images.githubusercontent.com/79500078/123815643-39b54680-d929-11eb-9423-a2ba0d2cc4f2.png)

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

![image](https://user-images.githubusercontent.com/79500078/124051255-ba219780-da4e-11eb-8a93-c97a73b4ecc8.png)

## UI Stack Manager

![image](https://user-images.githubusercontent.com/79500078/123814907-a9770180-d928-11eb-9ece-3fd425de3a66.png)

UIStackManager是UI Stack System的核心组件，这个组件通过一个StackADT对其所有子面板进行管理。

其中，UIStackManage所有可调用的UIPanelElement以<UIPanelElement, string>字典的形式储存在UIPanels中。Key是对应的UIPanelElement，Value是Panel name。

HasInitializePanel控制UI Stack Manager的初始化Panel。当取消勾选时，场景载入时将不会有Panel被压入UI Stack。

InitializationPanel是初始化压入的Panel，此Panel必须处于UIPanels中才可以被调用

## UI Stack 生命周期

![image](https://user-images.githubusercontent.com/79500078/123818674-c2cd7d00-d92b-11eb-84bd-96b6a2f625bf.png)

![image](https://user-images.githubusercontent.com/79500078/123818459-9580cf00-d92b-11eb-88dd-4b6f2169d7c0.png)

# 文档

Unity UI-Stack-System的使用文档请看[这里](https://fangjun-zhou.github.io/Unity-UI-Stack-System/)
