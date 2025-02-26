﻿using insertGuaXingtoPowerpnt;
using System.IO;
using System.Windows.Forms;

namespace CharacterConverttoCharacterPics
{
    public class DirFiles
    {//以後目錄、路徑均要取得最後的反斜線
        internal static string getDirRoot
        {//https://www.google.com/search?q=c%23+%E5%8F%96%E5%BE%97%E5%B0%88%E6%A1%88%E8%B7%AF%E5%BE%91&rlz=1C1JRYI_enTW948TW948&oq=%E5%8F%96%E5%BE%97%E5%B0%88%E6%A1%88%E8%B7%AF%E5%BE%91&aqs=chrome.1.69i57j0i5i30l2.7266j0j7&sourceid=chrome&ie=UTF-8
            get =>
                new DirectoryInfo(
                System.AppDomain.CurrentDomain.BaseDirectory)
                .Parent.Parent.Parent.FullName + "\\";
        }

        //古文字圖根目錄
        internal static string PicsRootFolder
        { get => Path華語文工具及資料 + "Macros\\古文字\\"; }

        //靜態筆順根目錄,不存在即回傳空字串
        internal static string PicsStaticStrokeOrderFolder
        {
            get
            {
                string p = Path華語文工具及資料 + @"!!@詞典附檔@!\筆順圖形\";
                if (Directory.Exists(p)) return p; else return "";
            }
        }

        internal static string Path華語文工具及資料
        {
            get
            {
                string dir;
                DriveInfo[] dis = DriveInfo.GetDrives();
                //List<string> dirs = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                foreach (DriveInfo di in dis)//(string item in dirs)
                {
                    //dir = item + ":\\@@@華語文工具及資料@@@" + subFolder;
                    dir = di.Name + "@@@華語文工具及資料@@@\\";
                    if (Directory.Exists(dir))
                    {
                        return dir;
                    }
                }
                return "";
            }
        }
        //without \
        internal static string getPicDir(picEnum pE)//without \
        {
            string subFolder;
            switch (pE)
            {
                case picEnum.卦圖64:
                    subFolder = "Macros\\64卦圖";
                    break;
                case picEnum.卦形8:
                    subFolder = "Macros\\64卦圖\\8卦圖";
                    break;
                case picEnum.小篆:
                    subFolder = "Macros\\古文字\\台大說文小篆字圖";
                    break;
                default://路徑特殊的就析出寫在上面20210410
                    subFolder = "Macros\\古文字\\" +
                       Application.OpenForms[0].Controls["listBox1"].Text;
                    break;
            }
            return Path華語文工具及資料 + subFolder;
        }
        internal static string getFullNameNTUswxz(string dir, string x)
        {//為免ADO存取資料庫失敗而增此
            return new FindFileThruLINQ().getfilefullnameIn古文字(x, dir);
        }

    }
}
