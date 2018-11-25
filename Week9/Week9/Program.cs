﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Collections;

namespace Week9
{
    public class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args)
        {
            Crawler myClawler = new Crawler();

            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1)
                startUrl = args[0];

            myClawler.urls.Add(startUrl, false);     //加入初始界面

            new Thread(myClawler.Crawl).Start();     //开始爬行
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了...");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url])           //已经下载过
                        continue;
                    current = url;
                }
                if (current == null || count > 10)
                    break;
                Console.WriteLine("爬行" + current + "页面！");

                string html = DownLoad(current);

                urls[current] = true;
                count++;

                Parse(html);
            }
            Console.WriteLine("爬行结束");
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";   //读取链接
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');
                if (strRef.Length == 0)
                    continue;
                if (urls[strRef] == null)
                    urls[strRef] = false;
            }
        }
    }
}