# IkorinLib

## 概要

c#自分用ライブラリ

## 詳細

### ConfigBase

汎用xml設定保存クラス。いろいろデータをxmlに出力したり読み込んだりしたいときにこれを継承すると便利かもよ。
使い方は一般的なSettingsと同じAPI。

というより、Settingsが任意の場所に設定を吐けないのでムシャクシャしてやった。後悔はしていない。

定義側

```csharp
[XmlRoot("設定")]
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
    Config.Path = "myconfig.xml";   // default: "Config.xml"
    Config.Load();                  // load from xml file
    
    Config.Default.SampleData = "ねむねむにゃんこ"
    Config.Save();                  // save to xml file
}
```

出力されるxml

```xml
<?xml version="1.0" encoding="utf-8"?>
<設定>
  <サンプル値>ねむねむにゃんこ</サンプル値>
</設定>
```

### WindowHelper

起動時に前回のWindow(wpf)の位置を復元するために、位置を取得・設定するやつ。
上記のConfigとかSettingsとかと合わせるといいんじゃないかな。知らにゃいニャ。

