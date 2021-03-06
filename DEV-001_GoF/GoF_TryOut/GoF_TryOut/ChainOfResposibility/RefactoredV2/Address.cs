﻿using System;

namespace GoF_TryOut.ChainOfResposibility.RefactoredV2 {
    public class Address {
        public string Country { get; set; }
        public string State { get; set; }
        public decimal DeliveryPrice { get; set; }


        public event Action DeliveryPriceChanged;
        public void SetDeliveryPrice(decimal price) {
            DeliveryPriceChanged();
        }
    }
}