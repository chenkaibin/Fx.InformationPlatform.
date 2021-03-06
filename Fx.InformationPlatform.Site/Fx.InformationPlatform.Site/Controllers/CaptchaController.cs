﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 验证码控制器
    /// </summary>
    public class CaptchaController : Controller
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CaptchaController()
        {
            this.Length = 4;
            this.FontSize = 14;
            this.Padding = 1;
            this.Chaos = false;
            this.ChaosColor = Color.LightGray;
            this.BackgroundColor = Color.White;
            this.Colors = new Color[] { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            this.Fonts = new string[] { "Arial", "Georgia" };
            this.CodeSerial = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
        }

        /// <summary>
        /// 生成校验码图片
        /// </summary>
        /// <returns>FileContentResult</returns> 
        public FileContentResult CreateImageCode()
        {
            string code = CreateVerifyCode(4);
            Session["PictureCode"] = code.ToUpper();
            int fSize = FontSize;
            int fWidth = fSize + Padding;
            int imageWidth = (int)(code.Length * fWidth) + 4 + Padding * 2;
            int imageHeight = fSize * 2 + Padding;
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(imageWidth, imageHeight);
            Graphics g = Graphics.FromImage(image);
            g.Clear(BackgroundColor);
            Random rand = new Random();
            //给背景添加随机生成的燥点
            if (this.Chaos)
            {
                Pen pen = new Pen(ChaosColor, 0);
                int c = Length * 10;
                for (int i = 0; i < c; i++)
                {
                    int x = rand.Next(image.Width);
                    int y = rand.Next(image.Height);
                    g.DrawRectangle(pen, x, y, 1, 1);
                }
            }
            int left = 0, top = 0, top1 = 1, top2 = 1;
            int n1 = (imageHeight - FontSize - Padding * 2);
            int n2 = n1 / 4;
            top1 = n2;
            top2 = n2 * 2;
            Font f;
            Brush b;
            int cindex, findex;
            //随机字体和颜色的验证码字符
            for (int i = 0; i < code.Length; i++)
            {
                cindex = rand.Next(Colors.Length - 1);
                findex = rand.Next(Fonts.Length - 1);
                f = new System.Drawing.Font(Fonts[findex], fSize, System.Drawing.FontStyle.Bold);
                b = new System.Drawing.SolidBrush(Colors[cindex]);
                if (i % 2 == 1)
                {
                    top = top2;
                }
                else
                {
                    top = top1;
                }
                left = i * fWidth;
                g.DrawString(code.Substring(i, 1), f, b, left, top);
            }
            //画一个边框 边框颜色为Color.Gainsboro
            g.DrawRectangle(new Pen(Color.Gainsboro, 0), 0, 0, image.Width - 1, image.Height - 1);
            g.Dispose();
            //产生波形
            image = TwistImage(image, true, 0, 4);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //将图像保存到指定的流
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return File(ms.GetBuffer(), "image/JPEG");
        }


     
        /// <summary>
        /// 验证码长度(默认4个长度)
        /// </summary>
        public int Length { get; set; }
   
        
        /// <summary>
        /// 验证码字体大小(为了显示扭曲效果，默认40像素)
        /// </summary>
        public int FontSize { get; set; }
        
        /// <summary>
        /// 边框补(默认1像素)
        /// </summary>
        public int Padding { get; set; }

        /// <summary>
        /// 是否输出燥点(默认不输出)
        /// </summary>
        public bool Chaos { get; set; }

        /// <summary>
        /// 输出燥点的颜色(默认灰色)
        /// </summary>
        public Color ChaosColor { get; set; }

        /// <summary>
        /// 自定义背景色(默认白色)
        /// </summary>
        public Color BackgroundColor { get; set; }
   
        /// <summary>
        /// 自定义随机颜色数组
        /// </summary>
        public Color[] Colors { get; set; }

        /// <summary>
        ///  自定义字体数组 默认Arial Georgia
        /// </summary>
        public string[] Fonts { get; set; }

       
        /// <summary>
        /// 自定义随机码字符串序列(使用逗号分隔) 默认0-9 a-z  A-Z
        /// </summary>
        public string CodeSerial { get; set; }
       
        private const double PI = 3.1415926535897932384626433832795;
        private const double PI2 = 6.283185307179586476925286766559;
        /// <summary>
        /// 正弦曲线Wave扭曲图片 产生波形滤镜效果
        /// </summary>
        /// <param name="srcBmp">图片路径</param>
        /// <param name="bXDir">如果扭曲则选择为True</param>
        /// <param name="dMultValue">波形的幅度倍数，越大扭曲的程度越高，一般为3</param>
        /// <param name="dPhase">波形的起始相位，取值区间[0-2*PI)</param>
        /// <returns></returns>
        public System.Drawing.Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            System.Drawing.Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
            // 将位图背景填充为白色
            System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();
            double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;
            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;
                    dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);
                    // 取得当前点的颜色
                    int nOldX = 0, nOldY = 0;
                    nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + (int)(dy * dMultValue);
                    System.Drawing.Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width
                     && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }
            return destBmp;
        }

       
        /// <summary>
        /// 生成随机字符码
        /// </summary>
        /// <param name="codeLen">长度</param>
        /// <returns>随即码</returns>
        public string CreateVerifyCode(int codeLen)
        {
            if (codeLen == 0)
            {
                codeLen = Length;
            }
            string[] arr = CodeSerial.Split(',');
            string code = "";
            int randValue = -1;
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < codeLen; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);
                code += arr[randValue];
            }
            return code;
        }

        /// <summary>
        /// 创建随即码
        /// </summary>
        /// <returns></returns>
        public string CreateVerifyCode()
        {
            return CreateVerifyCode(0);
        }

    }
}
