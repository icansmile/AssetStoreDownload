# AssetStoreDownload
在公司莫名其妙即使开了全局翻墙，也没法下载asset store上的东西，于是顺手写了个工具玩玩
## 使用
1.在unity中点了download后，mac中会在 /Users/YourAccount/Library/Unity/Asset Store-5.x/ 中生成两个隐藏文件
类似这样
> .Survival Shooter tutorial-content__40756.tmp\
> .Survival Shooter tutorial-content__40756.tmp.json 

2.在工具窗口中的json path填入json文件的路径（可直接拖动）\
3.点击Get，解析得到url和key\
4.复制url，用任意其他工具下载得到未解析的unitypackage（无后缀，不可使用）\
5.在package path中填入下载下来的unitypackage文件路径\
6.点击Decrypt,解析得到对应的.unitypackage文件\
![ToolBar](https://git.oschina.net/nick.c/nickimage/raw/master/AssetStoreDownload/ToolBar.png)

![ToolWindow](https://git.oschina.net/nick.c/nickimage/raw/master/AssetStoreDownload/ToolWindow.png)
## 知识点
1.反射\
2.UnityEditor扩展
