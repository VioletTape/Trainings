using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GoF_ShowCase.Prototype.ShallowDeep {
    [Serializable]
    public class MyClassName : IShallowCloneable, IDeepCloneable, ICloneable {
        // TODO: Add properties
        // TODO: Add fields
        // TODO: Add methods

        public object ShallowClone() {
            return MemberwiseClone();
        }

        public object DeepClone() {
            object clone = null;

            // Make deep copy using serialization
            using (var tempStream = new MemoryStream()) {
                var binFormatter = new BinaryFormatter(null,
                                                       new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                clone = binFormatter.Deserialize(tempStream);
            }

            return clone;
        }

        object ICloneable.Clone() {
            return DeepClone();
        }
    }
}