using System.Drawing;

namespace GoF_TryOut.State.Straight {
    public class Client {
        public Client() {
            var hero = new Hero();
            hero.Handle(new Input {
                Button = Button.B
            });


        }
    }

    public class Hero {
        

        private decimal yVelocity;
        private decimal xVelocity;
        private ImageServer imageServer;
        public bool IsJumping { get; set; }

        public Hero() {
            imageServer = new ImageServer();
        }


        public void Handle(Input input) {
            if (input.Button == Button.A && input.IsPressed) {
                if(IsJumping) {
                    IsJumping = true;
                    yVelocity = PhysX.JUMP_VELOCITY; 
                    SetGraphics(imageServer.GetImage("jump"));
                }
            }

            if (input.Button == Button.Down && input.IsPressed) {
                if(!IsJumping) {
                    SetGraphics(imageServer.GetImage("duck"));
                }
            }

            if (input.Button == Button.Down && !input.IsPressed) {
                SetGraphics(imageServer.GetImage("stand"));
            }
        }

        private void SetGraphics(Image image) {
            
        }
    }

    public class ImageServer {
        public Image GetImage(string name) {
            return new Bitmap(name);
        }
    }

    public static class PhysX {
        public const decimal JUMP_VELOCITY = 1.5m;
    }

    public struct Input {
        public Button Button;
        public bool IsPressed;
    }

    public enum Button {
        A,B,X,Y,
        Down, Up, Left, Right,
        R1, R2, L1, L2
    }
}