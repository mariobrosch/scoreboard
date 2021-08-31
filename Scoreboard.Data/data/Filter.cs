namespace Scoreboard.Data.data
{
    public static class Filter
    {
        public static string CreateFilter(string column, string value)
        {
            return "?filter[" + column + "]=" + value;
        }

        public static string CreateFilter(FilterObject filter)
        {
            return CreateFilter(filter.Column, filter.Value);
        }

        public static FilterObject Deserialize(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return new FilterObject();
            }
            var filterObject = new FilterObject();

            filter = filter.Replace("?filter[", "");
            filter = filter.Replace("]", "");
            var parts = filter.Split('=');

            filterObject.Column = parts[0];
            filterObject.Value = parts[1];

            return filterObject;
        }
    }
}
