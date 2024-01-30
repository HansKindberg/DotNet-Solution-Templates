using Microsoft.AspNetCore.Components;
using Shared.Net.Http;

namespace Spa.Pages
{
	public partial class Index : ComponentBase
	{
		#region Properties

		public string? BffApiError { get; private set; }
		public string? BffData { get; private set; }

		[Inject]
		protected internal IHttpClientFactory? HttpClientFactory { get; set; }

		public string? PublicApiError { get; private set; }
		public string? PublicData { get; private set; }

		#endregion

		#region Methods

		public async Task GetBffData()
		{
			this.BffApiError = null;
			this.BffData = null;

			try
			{
				using(var bffApiClient = this.HttpClientFactory!.CreateClient(HttpClientFactoryNames.Bff))
				{
					bffApiClient.DefaultRequestHeaders.Add("X-CSRF", "1");
					var response = await bffApiClient.GetAsync("/bff/example/get");
					this.BffData = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : throw new InvalidOperationException($"Error - {response.StatusCode}");
				}
			}
			catch(Exception exception)
			{
				this.BffData = null;
				this.BffApiError = $"Bff API error: {exception.Message}";
			}
		}

		public async Task GetPublicData()
		{
			this.PublicApiError = null;
			this.PublicData = null;

			try
			{
				using(var publicApiClient = this.HttpClientFactory!.CreateClient(HttpClientFactoryNames.Api))
				{
					var response = await publicApiClient.GetAsync("/advice");
					this.PublicData = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : throw new InvalidOperationException($"Error - {response.StatusCode}");
				}
			}
			catch(Exception exception)
			{
				this.PublicData = null;
				this.PublicApiError = $"Public API error: {exception.Message}";
			}
		}

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();

			// Custom initialization here.
		}

		#endregion
	}
}