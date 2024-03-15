namespace ReqnrollSelenium.StepDefinitions
{
    [Binding]
    public class AutenticacaoStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public AutenticacaoStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
        }

        private AutenticacaoPage autenticacaoPage;
        private AutenticacaoPage AutenticacaoPage => autenticacaoPage ??= new AutenticacaoPage(_driver);

        private ProdutosPage produtosPage;
        private ProdutosPage ProdutosPage => produtosPage ??= new ProdutosPage(_driver);

        [Given("que o usuário acessa o sistema {string}")]
        public void GivenQueOUsuarioAcessaOSistema(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        [When("solicita para realizar o login informando seus dados de autenticação")]
        public void WhenSolicitaParaRealizarOLoginInformandoSeusDadosDeAutenticacao(DataTable dataTable)
        {
            var (username, password) = dataTable.CreateInstance<(string username, string password)>();
            AutenticacaoPage.SetValuesAutenticationAndClickLoginButton(username, password);
        }

        [Then("acessa o sistema {string}")]
        public void ThenAcessaOSistema(string system)
        {
            var systemFound = ProdutosPage.GetTextPage();
            systemFound.Should().Be(system);
        }
    }
}

