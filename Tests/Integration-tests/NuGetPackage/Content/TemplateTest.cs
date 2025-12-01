using System.IO.Compression;
using NuGet.Packaging;

namespace IntegrationTests.NuGetPackage.Content
{
	public abstract class TemplateTest
	{
		#region Properties

		public abstract string BasePath { get; }
		public virtual string ReadMeHeading => "# Name-._76ff7a7e-._db48-._4849-._bc2c-._2790d679ce88";

		#endregion

		#region Methods

		public virtual PackageArchiveReader CreatePackageArchiveReader()
		{
			return new PackageArchiveReader(Global.NuGetPackageFile.FullName);
		}

		public virtual ZipArchiveEntry GetEntry(string filePath, PackageArchiveReader packageArchiveReader)
		{
			return packageArchiveReader.GetEntry($"{this.BasePath.TrimEnd('/')}/{filePath.TrimStart('/')}");
		}

		#endregion
	}
}