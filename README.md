# 5000兆円欲しい画像を生成するWindowsストアアプリ

![image](https://user-images.githubusercontent.com/48819514/112841521-8a739400-90db-11eb-91c5-157c8214b0e8.png)

## 概要

CyberRexさんが作った[5000choyen-api](https://github.com/CyberRex0/5000choyen-api)を利用してアプリで生成、保存できるようにしたものです

## インストール

Microsoft開発者アカウントを取得していないためStore以外からのインストールになります

[この](https://cdn.nerrog.net/5000choyen/)ページを開き、

![image](https://user-images.githubusercontent.com/48819514/112844652-ec81c880-90de-11eb-8668-62a18cf59605.png)

左の追加のリンクから公開者証明書をダウンロードしてインストールしてください
(インストール方法は[こちら](https://garafu.blogspot.com/2014/04/blog-post.html#wzd)を参考にして下さい)

※自動的に証明書ストアを選択したときに入らない場合があります

そのときは下の画像のように、「信頼されたユーザー」へインストールしてください

![image](https://user-images.githubusercontent.com/48819514/112845647-0ec81600-90e0-11eb-90f7-078ec3c528be.png)

インストールできたら、アプリを取得するをクリックして、「インストール」をクリックします。

![image](https://user-images.githubusercontent.com/48819514/112845550-edffc080-90df-11eb-89c6-f9e02b24bb30.png)

これでインストール完了です！

## **重要**

`アプリをインストールできませんでした。エラー メッセージ: エラー 0xC00CEE23: .appinstaller ファイルの XML が無効: 行 64、列 3、理由: '>' が必要です。 (0xc00cee23)`

と表示され、インストールできない不具合を確認しています

そのときは証明書をインストールしたあと

`アプリを取得する`ではなくPackage Bundleからappxbundleをダウンロードしてインストールしてください。

![image](https://user-images.githubusercontent.com/48819514/113007518-40f57880-91b1-11eb-8c26-72c482cf6151.png)



## 使用方法

テキストボックスに好きな文字列を入力して生成ボタンを押すと生成されます

生成された画像は右クリックメニューの「保存」から好きな場所に保存することができます

### オプションについて

![image](https://user-images.githubusercontent.com/48819514/112843133-3a95cc80-90dd-11eb-84e3-ac67f836fbe0.png)

この3つのオプションが使えます。

※[API](https://github.com/CyberRex0/5000choyen-api#parameters)の更新により、オプションが増減可能性があります

※現在ではpngのみサポートしています。他のフォーマットにも対応するかもしれません。

## Thanks

素晴らしいAPIを作成してくださった[CyberRex](https://github.com/CyberRex0)さん
