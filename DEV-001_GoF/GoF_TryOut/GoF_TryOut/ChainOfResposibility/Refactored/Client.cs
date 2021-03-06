﻿using System;

namespace GoF_TryOut.ChainOfResposibility.Refactored {
    public class Client {
        public Client() {
            var address = new Address();
            address.DeliveryPriceChanged += () => {
                if (address.DeliveryPrice > 0) {
                    Console.WriteLine("Delivery price is " + address.DeliveryPrice);
                }
                else {
                    Console.WriteLine("Can not deliver you postage");
                }
            };

            new LocalDeliveryService(
                new CountryManDelivery(
                    new LittlePonyExpress(),
                    new WorldExpress()),
                new AllUsaDelivery(
                    new LittlePonyExpress(),
                    new WorldExpress()),
                new LittlePonyExpressUsa(
                    new LittlePonyExpress(),
                    new WorldExpress())
                ).CalcDelivery(address);

            new LocalDeliveryService().CalcDelivery(address);
        }
    }

   
}