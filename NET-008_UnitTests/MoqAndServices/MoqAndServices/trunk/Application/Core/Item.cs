using System;

namespace Application.Core {
    public class Item {
        public Guid Id;
        public string Title;
        public double Price;

        public Item() {
            Id = Guid.NewGuid();
        }
    }
}