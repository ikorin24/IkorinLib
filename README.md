# IkorinLib

## 概要

c#自分用ライブラリ

## 詳細

### ConfigBase<T>

汎用xml設定クラス。ソフトの設定をxmlに出力したり読み込んだりしたいときにこれを継承すると便利かもよ。
使い方は一般的なSettingsと同じAPI。

定義側

```csharp
public class Config : ConfigBase<Config>
{
    [XmlElement("サンプル値")]
    public string SampleData { get; set; } = "default value";
}
```

使う側

```csharp
public void Method()
{
    Config.Load();        // load from xml file
    
    Config.Default.SampleData = "ねむねむにゃんこ"
    Config.Save();        // save to xml file
}
```

### WindowHelper

Window(wpf)の位置を記憶するために、位置を取得・設定するやつ。
上記のConfigとかSettingsとかと合わせるといいんじゃないかな。知らにゃいニャ。

