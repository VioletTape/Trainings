using System.Reflection;


/////
namespace NotificationBarLib.Core {
    public class ContextProperty {
        public PropertyInfo PropertyInfo;
        public object Value;

        public ContextProperty(PropertyInfo propertyInfo) {
            PropertyInfo = propertyInfo;
        }

        public void RetrieveValueFrom(object instance) {
            Value = PropertyInfo.GetValue(instance);
        }

        public void SetValueFor(PropertyInfo info, object instance) {
            if(info.Name == PropertyInfo.Name)
                info.SetValue(instance, Value);
        }
    }
}