using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.Drawing;

namespace İnstagram_Toplu_Gönderi_Silici
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeDriver drv;
            Console.Title = "İnstagram Toplu Gönderi Silici";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Website : https://kodzamani.weebly.com");
            Console.WriteLine("İletişim instagram : @kodzamani.tk");
            Console.WriteLine("-------------------------------------");

            ChromeOptions option = new ChromeOptions();
            option.EnableMobileEmulation("iPhone X");
            option.AddExcludedArgument("enable-automation");
            option.AddAdditionalCapability("useAutomationExtension", false);
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            drv = new ChromeDriver(service,option);
            drv.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
            string veri = "";
            for (; ; )
            {
                Console.WriteLine(DateTime.Now + " : Hesabınıza Giriş Yapmanız Bekleniyor.");
                Thread.Sleep(3000);
                try
                {
                    if (drv.Url.Contains("reactivated") == true)
                        drv.Navigate().GoToUrl("https://www.instagram.com/");
                     veri = drv.FindElement(By.XPath("/html/body/div[1]/section/nav[2]/div/div/div[2]/div/div/div[5]/a")).GetAttribute("href");
                    drv.Navigate().GoToUrl(veri+"feed");
                   drv.Manage().Window.Position = new Point(-32000, -32000);
                    break;
                }
                catch
                {

                }
            }
            Console.Clear();
            Console.WriteLine("Hoş Geldin :" + veri.Replace("/", ""));
            Console.WriteLine("------------------------------------");
            Console.WriteLine("İşlemler başlatılıyor.");
                Console.Clear();
            for (; ; )
            {
                try
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Kalan Gönderi Sayısı : " + drv.FindElement(By.XPath("//html/body/div[1]/section/main/div/ul/li[1]/span/span")).Text);
                    string alt = drv.FindElement(By.XPath("//html/body/div[1]/section/main/div/div[4]/div[1]/div/article[1]/div[3]/div[2]/a/time")).Text;
                    if (alt=="")
                        Console.WriteLine("Tarih : Bulunamadı.");
                    else
                    Console.WriteLine("Tarih : " + alt);
                    drv.FindElement(By.XPath("//html/body/div[1]/section/main/div/div[4]/div[1]/div/article[1]/div[1]/button")).Click();
                    Thread.Sleep(500);
                    drv.FindElement(By.XPath("//html/body/div[5]/div/div/div/div/button[1]")).Click();
                    Thread.Sleep(500);
                    drv.FindElement(By.XPath("//html/body/div[5]/div/div/div/div[2]/button[1]")).Click();
                    Thread.Sleep(500);
                    drv.Navigate().GoToUrl(veri + "feed");
                    Console.WriteLine("Silme İşlemi Başarılı.");
                }
                catch
                {
                    Console.WriteLine("Silme İşlemi Başarısız.");
                }
            }
        }
    }
}
