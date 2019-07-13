﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace Helper

{
    /// <summary>
    /// http连接基础类，负责底层的http通信
    /// </summary>
    public class HttpService
    {
        private static string USER_AGENT = string.Format("Helper.HttpServiceSDK /{3} ({0}) .net/{1} {2}", Environment.OSVersion, Environment.Version, "0", typeof(HttpService).Assembly.GetName().Version);

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开    
            return true;
        }


        public static T Get<T>(string url)
        {
            string http = Get(url);
            LogManager.WriteLog("httpservice.get", url + "\n\n" + http);
            return JsonConvert.DeserializeObject<T>(http);
        }

        public static T Post<T>(string url, string xml)
        {
            string http = Post(xml, url, false, 30);
            LogManager.WriteLog("httpservice.Post", url + "\n\n" + http);
            return JsonConvert.DeserializeObject<T>(http);
        }

        public static string Post(string xml, string url, bool isUseCert, int timeout)
        {
            LogManager.WriteLog("httpservice.Post", url + "\r\n" + xml);

            System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接

            string result = "";//返回结果

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream reqStream = null;

            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = USER_AGENT;
                request.Method = "POST";
                request.Timeout = timeout * 1000;

                //设置代理服务器
                //WebProxy proxy = new WebProxy();                          //定义一个网关对象
                //proxy.Address = new Uri(WxPayConfig.PROXY_URL);              //网关服务器端口:端口
                //request.Proxy = proxy;

                //设置POST的数据类型和长度
                request.ContentType = "text/xml";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                request.ContentLength = data.Length;

                //是否使用证书
                if (isUseCert)
                {
                    //string path = HttpContext.Current.Request.PhysicalApplicationPath;
                    //string path = "D:\\Desktop\\wxpay_xiaowei\\cs_sdk_v3.0.9\\WxPayAPI";
                    //X509Certificate2 cert = new X509Certificate2(path + WxPayConfig.GetConfig().GetSSlCertPath(), WxPayConfig.GetConfig().GetSSlCertPassword());
                    //request.ClientCertificates.Add(cert);
                    //Log.Debug("WxPayApi", "PostXml used cert");
                }

                //往服务器写入数据
                reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                //获取服务端返回
                response = (HttpWebResponse)request.GetResponse();

                //获取服务端返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                //Log.Error("HttpService", "Thread - caught ThreadAbortException - resetting.");
                //Log.Error("Exception message: {0}", e.Message);
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
                //Log.Error("HttpService", e.ToString());
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    //Log.Error("HttpService", "StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                    //Log.Error("HttpService", "StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                }
                throw new Exception(e.ToString());
            }
            catch (Exception e)
            {
                //Log.Error("HttpService", e.ToString());
                throw new Exception(e.ToString());
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }

        /// <summary>
        /// 处理http GET请求，返回数据
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <returns>http GET成功后返回的数据，失败抛WebException异常</returns>
        public static string Get(string url)
        {
            LogManager.WriteLog("httpservice.Get", url );

            System.GC.Collect();
            string result = "";

            HttpWebRequest request = null;
            HttpWebResponse response = null;

            //请求url以获取数据
            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = USER_AGENT;
                request.Method = "GET";

                //获取服务器返回
                response = (HttpWebResponse)request.GetResponse();

                //获取HTTP返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                //Log.Error("HttpService", "Thread - caught ThreadAbortException - resetting.");
                //Log.Error("Exception message: {0}", e.Message);
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
                //Log.Error("HttpService", e.ToString());
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    //Log.Error("HttpService", "StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                    //Log.Error("HttpService", "StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                }
                throw new Exception(e.ToString());
            }
            catch (Exception e)
            {
                //Log.Error("HttpService", e.ToString());
                throw new Exception(e.ToString());
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }


        /// <summary>
        /// 用于小微商户的函数实现
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="url"></param>
        /// <param name="isUseCert"></param>
        /// <param name="timeout"></param>
        /// <param name="ContentType"></param>
        /// <param name="Headers"></param>
        /// <returns></returns>
        public static string Get(string url, bool isUseCert, int timeout,
                                    string ContentType, WebHeaderCollection Headers)
        {

            LogManager.WriteLog("httpservice.Get", url  );

            System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接

            string result = "";//返回结果

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream reqStream = null;

            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/

                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Credentials = CredentialCache.DefaultCredentials;
                request.UserAgent = USER_AGENT;
                request.Method = "GET";
                request.Timeout = timeout * 1000;

                //设置代理服务器
                //WebProxy proxy = new WebProxy();                          //定义一个网关对象
                //proxy.Address = new Uri(WxPayConfig.PROXY_URL);              //网关服务器端口:端口
                //request.Proxy = proxy;

                //设置POST的数据类型和长度
                //request.ContentType = ContentType;
                request.Accept = "*/*";
                request.KeepAlive = true;

                //byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                //request.ContentLength = data.Length;

                for (int i = 0; i < Headers.Count; i++)
                {
                    request.Headers.Add(Headers.GetKey(i), Headers.Get(i));
                }


                //是否使用证书
                if (isUseCert)
                {
                    ////string path = HttpContext.Current.Request.PhysicalApplicationPath;
                    //string path = "D:\\Desktop\\wxpay_xiaowei\\cs_sdk_v3.0.9\\WxPayAPI";
                    //X509Certificate2 cert = new X509Certificate2(path + WxPayConfig.GetConfig().GetSSlCertPath(), WxPayConfig.GetConfig().GetSSlCertPassword());
                    //request.ClientCertificates.Add(cert);
                    //Log.Debug("WxPayApi", "PostXml used cert");
                }

                ////往服务器写入数据
                //reqStream = request.GetRequestStream();
                //reqStream.Write(data, 0, data.Length);
                //reqStream.Close();

                //获取服务端返回
                response = (HttpWebResponse)request.GetResponse();

                //获取服务端返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                //Log.Error("HttpService", "Thread - caught ThreadAbortException - resetting.");
                //Log.Error("Exception message: {0}", e.Message);
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException ex)
            {
                //Log.Error("HttpService", ex.ToString());
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {

                    //Log.Error("HttpService", "StatusCode : " + ((HttpWebResponse)ex.Response).StatusCode);
                    //Log.Error("HttpService", "StatusDescription : " + ((HttpWebResponse)ex.Response).StatusDescription);


                    //这里的代码能保证返回401时，正常显示信息
                    if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.Unauthorized)
                    {
                        response = (HttpWebResponse)ex.Response;
                        {
                            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            string bstr = sr.ReadToEnd();
                            return bstr;
                        }
                    }

                }

                //
                //if (ex.Status == WebExceptionStatus.NameResolutionFailure)
                //{
                //    throw new Exception("无法访问网络");
                //}

                //返回错误信息
                throw new Exception(ex.ToString());
            }

            catch (Exception e)
            {
                //Log.Error("HttpService", e.ToString());
                throw new Exception(e.ToString());
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }
    }
}