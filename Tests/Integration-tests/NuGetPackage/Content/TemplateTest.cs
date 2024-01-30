using System.IO.Compression;
using NuGet.Packaging;

namespace IntegrationTests.NuGetPackage.Content
{
	public abstract class TemplateTest
	{
		#region Properties

		public abstract string BasePath { get; }
		public virtual string ReadMeHeading => "# Name_76ff7a7e_db48_4849_bc2c_2790d679ce88";

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