using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

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

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string name_str = tb_name.Text;
            string num_str = tb_num.Text;
            Image image = Image.FromFile("base.jpg");
            using (Graphics g = Graphics.FromImage(image))
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;  // 更正： 垂直居中
                format.Alignment = StringAlignment.Center;      // 水平居中

                RectangleF rf_name = new Rectangle(new Point(183, 1879), new Size(693, 246));
                RectangleF rf_num = new Rectangle(new Point(195, 2125), new Size(693, 82));
                g.DrawString(name_str, new Font("微软雅黑", 200),
                    Brushes.Black, rf_name, format);
                g.DrawString(num_str, new Font("宋体", 50),
                    Brushes.DimGray, rf_num, format);
                g.Flush();
            }
            //image.Save(name_str + ".jpg");
            this.SaveImageForSpecifiedQuality(image, "已p\\"+name_str + ".jpg", 100);
        }
    }
}
