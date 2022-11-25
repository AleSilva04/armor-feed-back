using System.Net.Mime;
using System.Text;
using ArmorFeedApi.Enterprises.Domain.Services.Communication;
using ArmorFeedApi.Enterprises.Resources;
using ArmorFeedApi.Vehicles.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace ArmorFeedTest;

[Binding]
public class VehiclesServiceStepDefinition
{
    private readonly WebApplicationFactory<Program> _factory;

    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    private Task<HttpResponseMessage> Response { get; set; }
    private VehicleResource Course { get; set; }
    private EnterpriseResource Item { get; set; }
    
    private VehiclesServiceStepDefinition(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/sign-up is available")]
    public void GivenTheEndpointHttpsLocalhostApiVSignUpIsAvailable(int port, int enterpriseId)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v1/enterprise/{enterpriseId}/vehicles");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
    }

    [Given(@"A Enterprise is already stored in Enterpise's Data")]
    public async void GivenAEnterpriseIsAlreadyStoredInEnterpisesData(Table existingEnterpriseResource)
    {
        var directorUri = new Uri($"https://localhost:7017/api/v1/enterprise");
        var resource = existingEnterpriseResource.CreateSet<RegisterEnterpriseRequest>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        await Client.PostAsync(directorUri, content);
    }

    [When(@"A Post Request is Sent")]
    public async void WhenAPostRequestIsSent(Table existingDirectorResource)
    {
        var directorUri = new Uri($"https://localhost:7017/api/v1/enterprise");
        var resource = existingDirectorResource.CreateSet<RegisterEnterpriseRequest>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        await Client.PostAsync(directorUri, content);
    }

    [Then(@"A Response with Status (.*) is Recieved")]
    public async void ThenAResponseWithStatusIsRecieved(String expectedMessage)
    {
        var jsonExpectedMessage = expectedMessage.ToJson();
        var actualMessage = Response.Result.Content.ReadAsStringAsync().Result;
        var validMessage = actualMessage.Contains(jsonExpectedMessage);
        Assert.True(validMessage);
    }
}