namespace IntegrationTests.IO.Extensions
{
	public static class DirectoryExtension
	{
		#region Methods

		public static void Copy(DirectoryInfo destination, DirectoryInfo source)
		{
			foreach(var sourcePath in Directory.GetDirectories(source.FullName, "*", SearchOption.AllDirectories))
			{
				var destinationPath = sourcePath.Replace(source.FullName, destination.FullName);
				_ = Directory.CreateDirectory(destinationPath);
			}

			foreach(var sourcePath in Directory.GetFiles(source.FullName, "*.*", SearchOption.AllDirectories))
			{
				File.Copy(sourcePath, sourcePath.Replace(source.FullName, destination.FullName), true);
			}
		}

		#endregion
	}
}