using IntegrationTests.DotNetNew.Fixtures;

namespace IntegrationTests.DotNetNew
{
	public abstract class TemplateTest<TFixture>(TFixture fixture) : IClassFixture<TFixture> where TFixture : TemplateFixture
	{
		#region Properties

		protected TFixture Fixture { get; } = fixture;

		#endregion

		#region Methods

		protected virtual DirectoryInfo GetResourcesDirectory(string name)
		{
			return new DirectoryInfo(Path.Combine(Global.DotNetNewResourcesDirectory.FullName, this.Fixture.TemplateDirectoryName, name));
		}

		#endregion
	}
}