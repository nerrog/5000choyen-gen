﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;


// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace _5000choyen_gn
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        byte[] imageBytes;
        BitmapImage biSource;
        string type = "";

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string apiurl = "https://gsapi.cyberrex.ml/image";

            //Invalid Request対策
            if ((toptxt.Text == "") && (bottomtxt.Text == ""))
            {
                var msg = new ContentDialog();
                msg.Title = "エラー";
                msg.Content = "両方のテキストボックスが空です";
                msg.PrimaryButtonText = "OK";
                await msg.ShowAsync();
                return;
            }

            if (toptxt.Text != "")
            {
                apiurl += "?top="+ toptxt.Text;
            }

            if (toptxt.Text != "")
            {
                apiurl += "&bottom=" + bottomtxt.Text;
            }

            //オプション系
            if (Rainbow.IsChecked == true)
            {
                apiurl += "&rainbow=true";
            }
            if (hoshii.IsChecked == true)
            {
                apiurl += "&hoshii=true";
            }
            if (white.IsChecked == true)
            {
                apiurl += "&noalpha=true";
            }
            if (single.IsChecked == true)
            {
                apiurl += "&single=true";
            }

            //ファイル形式
            if (png.IsChecked == true)
            {
                apiurl += "&type=png";
                type = ".png";

            }
            else if (jpeg.IsChecked == true)
            {
                apiurl += "&type=jpg";
                type = ".jpg";
            }
            else if (webp.IsChecked == true)
            {
                apiurl += "&type=webp";
                type = ".webp";
            }

                //APIから画像をダウンロードしてbyte型でメモリ上に保存
                //byte型なのは後に画像保存するときに2重でダウンロードしないため
                //Imageに表示させるためにbyte型からBitmapImageへ変換

                using (var webClient = new WebClient())
            {
                try
                {
                    imageBytes = webClient.DownloadData(apiurl);
                    biSource = new BitmapImage();
                    using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                    {
                        await stream.WriteAsync(imageBytes.AsBuffer());
                        stream.Seek(0);
                        await biSource.SetSourceAsync(stream);
                        Debug.WriteLine(apiurl);
                        showimg.Source = biSource;
                    }
                    
                }
                catch (WebException ex)
                {
                   if (ex.Status == WebExceptionStatus.ProtocolError) {
                        System.Net.HttpWebResponse errres =
                            (System.Net.HttpWebResponse)ex.Response;
                        if ((int)errres.StatusCode != 200)
                        {
                            var msg = new ContentDialog();
                            msg.Title = "エラー";
                            msg.Content = $"APIステータスコード:{(int)errres.StatusCode}";
                            msg.PrimaryButtonText = "OK";
                            await msg.ShowAsync();
                        }
                    }
                }
            }


        }
        
        private async void SaveImage_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.FileTypeChoices.Add($"{type} File", new List<string> { type });
            StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                //byteからIBufferに変換してWriteBufferAsyncを使うことでアクセス拒否を回避することができる
                IBuffer buf = imageBytes.AsBuffer();
                await Windows.Storage.FileIO.WriteBufferAsync(file, buf);
            }
        }

    }
}
