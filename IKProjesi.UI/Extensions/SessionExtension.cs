using System.Text.Json;

namespace IKProjesi.UI.Extensions
{
    public static class SessionExtension
    {
        public static void AddObjectSession<T>(this ISession session, T model) where T : class
        {
            Type type = typeof(T);
            string jsonModel = JsonSerializer.Serialize(model);
            session.SetString(type.Name, jsonModel);
        }

        public static T GetObjectSession<T>(this ISession session) where T : class
        {
            Type type = typeof(T);
            string jsonModel = session.GetString(type.Name);
            T model = JsonSerializer.Deserialize<T>(jsonModel);
            return model;
        }
    }
}
