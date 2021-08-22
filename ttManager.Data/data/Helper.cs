namespace ttManager.Data.data
{
    internal static class Helper
    {
        public static void SetProperty(this object obj, string propName, object value)
        {
            obj.GetType().GetProperty(propName).SetValue(obj, value, null);
        }
    }
}
