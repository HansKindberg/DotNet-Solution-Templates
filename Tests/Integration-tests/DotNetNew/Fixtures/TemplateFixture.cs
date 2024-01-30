using IntegrationTests.IO.Extensions;
using IntegrationTests.SimpleExec.Extensions;

namespace IntegrationTests.DotNetNew.Fixtures
{
	public abstract class TemplateFixture : IDisposable
	{
		#region Fields

		private const string _prefix = "Temporary-for-testing";

		#endregion

		#region Constructors

		protected TemplateFixture(string templateDirectoryName, string templateIdentity, string templateName, string templateShortName)
		{
			this.Directory = new DirectoryInfo(Path.Combine(Global.DotNetNewContentDirectory.FullName, templateDirectoryName));
			this.Id = Guid.NewGuid();
			this.TemplateDirectoryName = templateDirectoryName;
			this.TemplateIdentity = _prefix + ": " + templateIdentity + " | " + this.Id;
			this.TemplateName = _prefix + ": " + templateName + " | " + this.Id;
			this.TemplateShortName = (_prefix + "-" + templateShortName + "-" + this.Id).ToLowerInvariant();

			if(this.Directory.Exists)
				this.Directory.Delete(true);

			var source = new DirectoryInfo(Path.Combine(Global.TemplatesContentDirectory.FullName, templateDirectoryName));

			DirectoryExtension.Copy(this.Directory, source);

			var templateFilePath = Path.Combine(this.Directory.FullName, ".template.config", "template.json");
			var templateFileContent = File.ReadAllText(templateFilePath);

			templateFileContent = templateFileContent.Replace($"\"identity\": \"{templateIdentity}\"", $"\"identity\": \"{this.TemplateIdentity}\"");
			templateFileContent = templateFileContent.Replace($"\"name\": \"{templateName}\"", $"\"name\": \"{this.TemplateName}\"");
			templateFileContent = templateFileContent.Replace($"\"shortName\": \"{templateShortName}\"", $"\"shortName\": \"{this.TemplateShortName}\"");

			File.WriteAllText(templateFilePath, templateFileContent);

			// ReSharper disable EmptyGeneralCatchClause
			try
			{
				// Trying cleanup if the directory is left from previous tests.
				this.UninstallTemplate();
			}
			catch { }
			// ReSharper restore EmptyGeneralCatchClause

			this.InstallTemplate();
		}

		#endregion

		#region Properties

		protected DirectoryInfo Directory { get; }
		public Guid Id { get; }
		public string TemplateDirectoryName { get; }
		protected string TemplateIdentity { get; }
		public string TemplateName { get; }
		public string TemplateShortName { get; }

		#endregion

		#region Methods

		public virtual void Dispose()
		{
			this.UninstallTemplate();

			if(this.Directory.Exists)
				this.Directory.Delete(true);

			GC.SuppressFinalize(this);
		}

		private void InstallTemplate()
		{
			CommandExtension.Run($"dotnet new install \"{this.Directory}\"");
		}

		private void UninstallTemplate()
		{
			CommandExtension.Run($"dotnet new uninstall \"{this.Directory}\"");
		}

		#endregion
	}
}