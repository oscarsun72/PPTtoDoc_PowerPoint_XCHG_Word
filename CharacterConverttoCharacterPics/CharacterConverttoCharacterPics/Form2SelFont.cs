﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using powerPnt = Microsoft.Office.Interop.PowerPoint;

namespace CharacterConverttoCharacterPics
{
    public partial class Form2SelFont : Form
    {
        public Form2SelFont()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font fnt = new Font(listBox1.SelectedItem.ToString(),
                label1.Font.Size);
            label1.Font = fnt; label2.Font = fnt;
        }

        private void Form2SelFont_Load(object sender, EventArgs e)
        {
            if (FontsOpsDoc.docFontNames.Count > 0)
            {
                List<string> ls = new List<string>(),
                    lsOK = FontsOpsDoc.fontOkList,
                    lsFonts = FontsOpsDoc.docFontNames;
                foreach (string item in lsFonts)
                {
                    if (lsOK.Contains(item) == false)
                    {
                        ls.Add(item);
                    }
                }
                listBox1.DataSource = ls;
            }
        }

        public string FontNameWanted { get => listBox1.SelectedItem.ToString(); }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            selectFontWanted();
        }

        private void selectFontWanted()
        {
            powerPnt.Presentation ppt = new DirFiles().get字圖母片pptm();
            //App.PptAppOpenByCode = false;
            ppt.Slides[2].Shapes[1].TextFrame.TextRange.Font.NameFarEast =
                FontNameWanted;
            ppt.Slides[2].Select();
            ppt.Slides[2].Shapes[1].TextFrame.TextRange.Select();
            ppt.Application.WindowState = powerPnt.PpWindowState.ppWindowMaximized;
            ppt.Application.Activate();
            Clipboard.SetText(listBox1.SelectedItem.ToString());
            List<string> ls = new List<string>();
            int idx = listBox1.SelectedIndex;
            for (int i = 0; i < idx; i++)
            {//目前選中的字型還沒做好，就不要自動加入已做清單中
                ls.Add(listBox1.Items[i].ToString());
            }
            DirFiles.appendFontOkList_txt(ls, FontsOpsDoc.fontOkList);
            //Application.OpenForms["Form1"].Controls["textBox2"].Text =
            //    listBox1.SelectedItem.ToString();
            ppt.Application.Activate(); Application.DoEvents();
            Form1.Close字圖母片 = false;
            Close();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    selectFontWanted();
                    break;
                default:
                    break;
            }
            switch (ModifierKeys)
            {
                case Keys.Shift:
                    break;
                case Keys.Control:
                    if (listBox1.SelectedItems.Count > 0)
                        if (e.KeyCode == Keys.C)
                        {
                            Clipboard.SetText(
                                listBox1.SelectedItem.ToString());
                            doNotEntered = true;
                        }
                    break;
                case Keys.Alt:
                    break;
                default:
                    break;
            }
        }
        bool doNotEntered = false;
        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (doNotEntered)//不讓按鍵干擾操作
            { e.Handled = true; doNotEntered = false; }
        }
    }
}
