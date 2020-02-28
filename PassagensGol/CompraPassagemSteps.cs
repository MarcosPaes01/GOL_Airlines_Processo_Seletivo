using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PassagensGol
{
    [Binding]
    public class CompraPassagemSteps
    {

        IWebDriver driver;
        string url = "https://www.voegol.com.br/pt";


        [BeforeScenario]
        public void Inicio()
        {
            this.driver = new ChromeDriver();
        }

        [AfterScenario]
        public void Fim()
        {
            this.driver.Close();
            this.driver.Dispose();
        }

        [Given(@"que o usuário acessa a página https://www\.voegol\.com\.br/pt")]
        public void DadoQueOUsuarioAcessaAPaginaHttpsWww_Voegol_Com_BrPt()
        {
            driver.Navigate().GoToUrl(url);
        }

        [When(@"o usuário seleciona a origem e destino")]
        public void QuandoOUsuarioSelecionaAOrigemEDestino()
        {

            //Usados xpaths para localixação de elementos, pela não funcionalidade de IDs, Names e ClassNames
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Name("header-chosen-origin")).SendKeys("Santos Dumont");
            driver.FindElement(By.CssSelector(".active-result")).Click();
            driver.FindElement(By.CssSelector(".chosen-with-drop")).Click();
            driver.FindElement(By.XPath("//div[@id='purchase-box']/form[2]/div/div[3]/div/div/div/div/input")).SendKeys("Guarulhos");
            driver.FindElement(By.XPath("//div[3]/div/div/div/ul/li/em")).Click();

            driver.FindElement(By.CssSelector(".chosen-container-active .active-result")).Click();
        }

        [When(@"o usuário informa as datas de ida e volta")]
        public void QuandoOUsuarioInformaAsDatasDeIdaEVolta()
        {
            driver.FindElement(By.CssSelector(".calendar-go .month")).Click();
            driver.FindElement(By.Id("datepickerGo")).SendKeys("27/02/2020");
            driver.FindElement(By.CssSelector(".purchase-box-body-buy")).Click();
            driver.FindElement(By.CssSelector(".calendar-back .month-year")).Click();
            driver.FindElement(By.Id("datepickerBack")).SendKeys("15/08/2020");
            driver.FindElement(By.CssSelector(".purchase-box-body-buy")).Click();

        }

        [When(@"o usuário informa a quantidade de passageiros")]
        public void QuandoOUsuarioInformaAQuantidadeDePassageiros()
        {
            driver.FindElement(By.Id("number-adults")).Click();
            driver.FindElement(By.Id("number-adults")).SendKeys("2");
            driver.FindElement(By.CssSelector(".purchase-box-buy-numbers")).Click();
            
        }
        
        [When(@"o usuário seleciona as duas passagens")]
        public void QuandoOUsuarioSelecionaAsDuasPassagens()
        {
            driver.FindElement(By.Id("btn-box-buy")).Click();
            
        }
        
        [Then(@"o sistema retorna as passagems dispon\[iveis")]
        public void EntaoOSistemaRetornaAsPassagemsDisponIveis()
        {
            driver.FindElement(By.Id("ControlGroupSelect2View_AvailabilityInputSelect2View_RadioButtonMkt1Fare5")).Click();
            driver.FindElement(By.Id("ControlGroupSelect2View_AvailabilityInputSelect2View_RadioButtonMkt2Fare10")).Click();

        }

        [Then(@"o sistema calcula os valores e direciona para a tela de pagamento")]
        public void EntaoOSistemaCalculaOsValoresEDirecionaParaATelaDePagamento()
        {
            //Busca elemento na tela de pagamento
            driver.FindElement(By.Name("LoginMemberLogin2View$TextBoxUserID"));

        }
    }
}
