using System.Drawing;
using System.Threading.Tasks;

namespace GoF_TryOut.Proxy.Straight {
    public class Client {
        public Client() {
            var myImage = new MyImage("");
            var bitmap = myImage.GetImage() ?? myImage.GetPreview();
        }
    }

    public class MyImage {
        private readonly string path;
        private readonly Bitmap preview;
        private Bitmap fullImage;
        private Task<Bitmap> task;


        public MyImage(string path) {
            this.path = path;

            preview = new Bitmap(path);
        }

        private Bitmap LoadImage() {
            return new Bitmap(path);
        }

        public Bitmap GetPreview() {
            return preview;
        }

        public Bitmap GetImage() {
            task = new Task<Bitmap>(LoadImage);
            task.Start();

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
}