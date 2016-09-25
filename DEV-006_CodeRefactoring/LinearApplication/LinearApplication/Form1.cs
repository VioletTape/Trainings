using System;
using System.Windows.Forms;

namespace LinearApplication {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            var oper = true;


            var textbox = new TextBox {
                Text = "0",
                TextAlign = HorizontalAlignment.Right,
                Width = 100,
                Height = 30
            };

            var button = new Button {
                Text = "+",
                Width = 50,
                Height = 50,
                Top = 50,
                Left = 0
            };

            Controls.Add(button);
            Controls.Add(textbox);

            var button1 = new Button {
                Text = "-",
                Width = 50,
                Height = 50,
                Top = 50,
                Left = 50
            };

            var memory = 0;
            textbox.Leave += (EventHandler) ((s, a) => {
                memory = oper
                    ? memory + Int32.Parse(textbox.Text)
                    : memory - Int32.Parse(textbox.Text);
            });
            Controls.Add(button1);

            button.Click += (sender, e) => {
                oper = true;

                textbox.Text = "0";
            };

            var button2 = new Button {
                Text = "=",
                Width = 50,
                Height = 50,
                Top = 50,
                Left = 100
            };

            var button3 = new Button {
                Text = "CE",
                Width = 50,
                Height = 50,
                Top = 50,
                Left = 150
            };
            button3.Click += (EventHandler) ((s, a) => {
                ((TextBox) textbox).Text = "0";
                memory = 0;
            });


            Controls.Add(button2);
            Controls.Add(button3);


            button1.Click += (EventHandler) ((s, a) => {
                oper = false;

                textbox.Text = "0";
            });


            button2.Click += (EventHandler) ((s, a) => { textbox.Text = memory.ToString(); });
        }
    }
}