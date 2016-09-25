using System.Drawing;
using System.Threading.Tasks;

namespace GoF_TryOut.Proxy.Refactored {
    public class Client {
         
    }

     public abstract class MyImage {
        private readonly string path;
        private readonly Bitmap preview;
        private Bitmap fullImage;
        private readonly Task<Bitmap> task;


        public MyImage(string path) {
            this.path = path;

            preview = new Bitmap(path);

            task = new Task<Bitmap>(LoadImage);
        }



        private Bitmap LoadImage() {
            return new Bitmap(path);
        }

        public Bitmap GetPreview() {
            return preview;
        }

        public Bitmap GetImage() {
            if (task.IsCompleted) {
                if (fullImage == null) {
                    fullImage = task.Result;
                    return fullImage;
                }
                return fullImage;
            }
            return preview;
        }
    }

    public class MyImageProxy {
        
    }

    public class MyImageReal {
        
    }
}