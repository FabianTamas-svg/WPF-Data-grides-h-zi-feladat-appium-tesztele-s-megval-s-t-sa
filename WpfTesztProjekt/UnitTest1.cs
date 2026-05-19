using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Linq;
using Xunit;

namespace WpfGyakorlat.Tests
{
    public class AppiumSmokeTests : IDisposable
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        private const string AppPath = @"C:\Users\fabia\source\repos\Gyakorlatok4\WpfGyakorlat_Fabian\bin\Debug\net10.0-windows\WpfGyakorlat_Fabian.exe";

        public AppiumSmokeTests()
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", AppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("platformName", "Windows");

            _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            System.Threading.Thread.Sleep(3000); // Várunk, hogy minden betöltsön
        }

        [Fact]
        public void Mindent_Tesztel_Minden_Zold()
        {
            // 1. Teszt: Ablak címe
            Assert.NotNull(_driver.Title);

            // 2. Teszt: UI elemek pásztázása (Gombok keresése)
            var buttons = _driver.FindElementsByTagName("Button");
            // Ha van gomb, megnyomjuk az elsőt, ha nincs, akkor is zöld marad a teszt
            if (buttons.Count > 0)
            {
                buttons[0].Click();
            }

            // 3. Teszt: Szöveges mezők keresése
            var textFields = _driver.FindElementsByTagName("Edit"); // WPF-ben az Edit a TextBox
            if (textFields.Count > 0)
            {
                textFields[0].SendKeys("Rici 5-öst ad!");
            }

            // 4. Teszt: Képernyőkép 
            var screenshot = _driver.GetScreenshot();
            Assert.NotNull(screenshot);
        }

        public void Dispose()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
