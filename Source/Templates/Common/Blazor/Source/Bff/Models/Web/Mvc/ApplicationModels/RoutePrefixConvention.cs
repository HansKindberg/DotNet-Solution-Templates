using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Bff.Models.Web.Mvc.ApplicationModels
{
	public class RoutePrefixConvention(string routePrefix) : IApplicationModelConvention
	{
		#region Properties

		protected internal virtual AttributeRouteModel RoutePrefix { get; } = new(new RouteAttribute(routePrefix));

		#endregion

		#region Methods

		public virtual void Apply(ApplicationModel application)
		{
			foreach(var selector in application.Controllers.SelectMany(controller => controller.Selectors))
			{
				selector.AttributeRouteModel = selector.AttributeRouteModel != null
					? AttributeRouteModel.CombineAttributeRouteModel(this.RoutePrefix, selector.AttributeRouteModel)
					: this.RoutePrefix;
			}
		}

		#endregion
	}
}