using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace HeadHorseOfTuanzhang
{
    
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public bool SaveImageForSpecifiedQuality(System.Drawing.Image sourceImage, string savePath, int imageQualityValue)
        {
            //以下代码为保存图片时，设置压缩质量
            EncoderParameters encoderParameters = new EncoderParameters();
            EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, imageQualityValue);
            encoderParameters.Param[0] = encoderParameter;
            try
            {
                ImageCodecInfo[] ImageCodecInfoArray = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegImageCodecInfo = null;
                for (int i = 0; i < ImageCodecInfoArray.Length; i++)
                {
                    if (ImageCodecInfoArray[i].FormatDescription.Equals("JPEG"))
                    {
                        jpegImageCodecInfo = ImageCodecInfoArray[i];
                        break;
                    }
                }
                sourceImage.Save(savePath, jpegImageCodecInfo, encoderParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void draw_pic(string prefix, string name_str, string num_str, string pic_name, RectangleF rf_name)
        {
            Image image = Image.FromFile(pic_name + ".jpg");
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("PingFang Heavy.ttf");
            using (Graphics g = Graphics.FromImage(image))
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;  // 更正： 垂直居中
                format.Alignment = StringAlignment.Center;      // 水平居中

                //RectangleF rf_name = new Rectangle(new Point(183, 1879), new Size(693, 246));
                //RectangleF rf_name = new Rectangle(new Point(229, 812), new Size(397, 126));
                //RectangleF rf_num = new Rectangle(new Point(195, 2125), new Size(693, 82));
                //RectangleF rf_num = new Rectangle(new Point(229, 918), new Size(397, 42));
                //g.DrawString(name_str, new Font("微软雅黑", 72),
                //    Brushes.Black, rf_name, format);
                g.DrawString(prefix + name_str, new Font(pfc.Families[0], 74),
                    Brushes.Black, rf_name, format);
                //g.DrawString(num_str, new Font("宋体", 25),
                    //Brushes.DimGray, rf_num, format);
                g.Flush();
            }
            //image.Save(name_str + ".jpg");
            this.SaveImageForSpecifiedQuality(image, "输出\\" + num_str + name_str + ".jpg", 100);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (!File.Exists(tb_file.Text)) {
                MessageBox.Show("请选择Excel！");
                return;
            }
            string pic_name;
            RectangleF rf_name;
            if ("机智云" == cb_pic.Text)
            {
                pic_name = "gizwits";
                rf_name = new Rectangle(new Point(125, 1010), new Size(490, 101));
            }
            else if ("五号空间" == cb_pic.Text)
            {
                pic_name = "no5";
                rf_name = new Rectangle(new Point(125, 870), new Size(490, 101));
            }
            else
            {
                MessageBox.Show("无效的底图！");
                return;
            }
            ExcelHelper eh = new ExcelHelper(tb_file.Text);
            string[,] name_arr = eh.GetContent();
            eh.Close();
            int len = name_arr.GetLength(0);
            if (len < 1) {
                MessageBox.Show("Excel中无有效数据！");
                return;
            }
            string prefix = "诚邀：";
            for (int i = 0; i < len; i++)
            {
                //System.Console.WriteLine(name_arr[i, 0] + name_arr[i, 1]);
                draw_pic(prefix, name_arr[i, 1], name_arr[i, 0], pic_name, rf_name);
            }

        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            if (ofd_excel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tb_file.Text = ofd_excel.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class ExcelHelper
    {
        private Excel._Application excelApp;
        private string fileName = string.Empty;
        private Excel.WorkbookClass wbclass;
        public ExcelHelper(string _filename)
        {
            excelApp = new Excel.Application();
            object objOpt = System.Reflection.Missing.Value;
            wbclass = (Excel.WorkbookClass)excelApp.Workbooks.Open(_filename, objOpt, false, objOpt, objOpt, objOpt, true, objOpt, objOpt, true, objOpt, objOpt, objOpt, objOpt, objOpt);
        }
        /**/
        /// <summary>
        /// 所有sheet的名称列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetSheetNames()
        {
            List<string> list = new List<string>();
            Excel.Sheets sheets = wbclass.Worksheets;
            string sheetNams = string.Empty;
            foreach (Excel.Worksheet sheet in sheets)
            {
                list.Add(sheet.Name);
            }
            return list;
        }
        public Excel.Worksheet GetWorksheetByName(string name)
        {
            Excel.Worksheet sheet = null;
            Excel.Sheets sheets = wbclass.Worksheets;
            foreach (Excel.Worksheet s in sheets)
            {
                if (s.Name == name)
                {
                    sheet = s;
                    break;
                }
            }
            return sheet;
        }
        /**/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetName">sheet名称</param>
        /// <returns></returns>
        public string[,] GetContent()
        {
            string sheetName = GetSheetNames()[0];
            Excel.Worksheet sheet = GetWorksheetByName(sheetName);

            //不为空的区域,列,行数目
            //int columns = sheet.UsedRange.Columns.Count;
            int rows = sheet.UsedRange.Rows.Count;
            if (rows < 2) { 
                return new string[0,0];
            }
            Excel.Range rng_a = sheet.Cells.get_Range("A2", "A" + rows);
            Excel.Range rng_b = sheet.Cells.get_Range("B2", "B" + rows);
            string[,] arry = new string[rows - 1, 2];
            if (rows < 3) {
                //A列
                arry[0, 0] = rng_a.Value2.ToString();
                //B列
                arry[0, 1] = rng_b.Value2.ToString();
            }
            else {
                object[,] arr_a = (object[,])rng_a.Value2;
                object[,] arr_b = (object[,])rng_b.Value2;
                for (int i = 1; i <= rows - 1; i++)
                {
                    //A列
                    arry[i - 1, 0] = arr_a[i, 1].ToString();
                    //B列
                    arry[i - 1, 1] = arr_b[i, 1].ToString();
                }
            }
            
            return arry;
        }

        public void Close()
        {
            excelApp.Quit();
            excelApp = null;
        }

    }
}
