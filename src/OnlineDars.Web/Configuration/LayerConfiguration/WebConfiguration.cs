namespace OnlineDars.Web.Configuration.LayerConfiguration
{
	public static class WebConfiguration
	{
		public static void ConfigureWeb(this IServiceCollection service, IConfiguration configuration)
		{
			service.ConfigureAuth(configuration);	

		}
	}
}
