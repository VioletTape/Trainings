using System;
using Application.Models;
using Application.Services;
using Application.Services.Interfaces;
using StructureMap;

namespace Application {
    internal class Program {
        private static void Main(string[] args) {
            InitStructureMape();


            var model = new Model {
                                      Print = Console.WriteLine
                                  };
            model.InitModel();

            var input = "";
            do {
                input = Console.ReadLine();
                model.ProcessAnswer(input);



            } while (input != "exit");
        }

        private static void InitStructureMape() {
            ObjectFactory.Configure(x => {
                                        x.For<IDataFacade>().Use<DataFacade>();
                                        x.For<ICustomerLoadService>().Use<CustomerLoadService>();
                                        x.For<IOrderService>().Use<OrderService>();
                                    });

            var whatDoIHave = ObjectFactory.WhatDoIHave();
        }
    }
}