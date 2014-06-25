using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ExecApp.Views;
using NotificationBarLib;
using Presentation.Models;
using Presentation.ViewInterfaces;
using StructureMap;

namespace ExecApp {
    public partial class MainWindow : Window, INotificationViewManager, IViewManager {
        private  Dictionary<Type, UserControl> views;
//        private  Dictionary<Type, BaseModel> models;
        private  Dictionary<Type, Type> models;


        public MainWindow() {
            InitializeComponent();
        }

        private void WindowInitialized(object sender, EventArgs e) {
            ObjectFactory.Configure(x => {
                                        x.For<INotificationViewManager>().Use(this);
                                        x.For<IViewManager>().Use(this);
                                        x.For<ILocalViewManager>().Use(notificationBar);
                                    });

            views = new Dictionary<Type, UserControl> {
                                                          {typeof (IStartScreen), new StartScreen()},
                                                          {typeof (IStarsAndRains), new MultipleNotificationView()},
                                                          {typeof (ISingleNotification), new SingleNotificationView()},
                                                      };
//            models = new Dictionary<Type, BaseModel> {
            models = new Dictionary<Type, Type> {
//                 special case of recreation of object
                                                    {typeof (IStartScreen), typeof (StartScreenModel)},
                                                    {typeof (IStarsAndRains), typeof (StarsAndRainsModel)},
                                                    {typeof (ISingleNotification), typeof (SingleNotificationModel)},
// more ordinal case
//                                                         {typeof (IStartScreen), new StartScreenModel()},
//                                                         {typeof (IStarsAndRains), new SeveralNotificationModel()},
                                                     };
            Show<IStartScreen>();

            notificationBar.SetStatusMessage("Готово");
        }

        public void Show<T>() {
            Show(typeof (T));
        }

        public void Show(Type type) {
            var userControl = views[type];
            var modelType = models[type];

            Content.Children.Clear();
            var instance = (BaseModel) Activator.CreateInstance(modelType);
//            var instance = modelType;
            instance.InitModel();

            userControl.DataContext = instance;

            Content.Children.Add(userControl);
            CurrentViewInterface = type;
        }

        public Type CurrentViewInterface { get; set; }

        void INotificationViewManager.Show(Type screenType) {
            Show(screenType);
        }
    }
}