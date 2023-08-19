using System.Text.RegularExpressions;

namespace RoutingExample.CustomConstraint
{
    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey(routeKey))
            {
                return false;
            }
            Regex regex = new Regex("^(apr|jul|oct|dec)$");
            string? month = Convert.ToString(values[routeKey]);
            return month != null && regex.IsMatch(month);
        }
    }
}
