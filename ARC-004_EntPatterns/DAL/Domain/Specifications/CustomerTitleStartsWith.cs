using SpecificationMain;

namespace Domain.Specifications {
    public class CustomerTitleStartsWith : Specification<Customer> {
        public string StartPattern { get; private set; }

        public CustomerTitleStartsWith(string startPattern) {
            StartPattern = startPattern;
        }

        public override bool IsSatisfiedBy(Customer obj) {
            return obj.Title.StartsWith(StartPattern);
        }
    }
}