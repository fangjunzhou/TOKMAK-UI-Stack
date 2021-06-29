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
