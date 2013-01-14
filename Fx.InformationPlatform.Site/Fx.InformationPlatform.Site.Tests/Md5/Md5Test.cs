using System;
using Fx.Infrastructure.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fx.InformationPlatform.Site.Tests.Md5
{
    /// <summary>
    /// js对字符串进行md5加密 C#进行解密
    /// </summary>
    [TestClass]
    public class Md5Test
    {
        [TestMethod]
        public void JsMd5()
        {
            //string input = "123456";
            //string md5 = "e10adc3949ba59abbe56e057f20f883e";
        }



        public void CSharpMd5()
        {
            string input = "123456";
            Console.WriteLine(Fx.Infrastructure.Security.Md5.MD5Encrypt(input,""));
        }
    }
}
