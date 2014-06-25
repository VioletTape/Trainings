namespace GoF_ShowCase.Prototype.FactoryPrototype {
    public static class ElementFactory {
        private static readonly BoxElement boxPropotype;
        private static readonly CircleElement circlePropotype;
        private static readonly ConnectorElement connectorPropotype;

        static ElementFactory() {
            // Create and setup prototypes
            boxPropotype = new BoxElement();
            boxPropotype.Title = "New box element";

            circlePropotype = new CircleElement();
            circlePropotype.Title = "New circle element";

            connectorPropotype = new ConnectorElement();
            connectorPropotype.Title = "New connector";
        }

        public static BoxElement CreateBox() {
            return (BoxElement) boxPropotype.Clone();
        }

        public static CircleElement CreateCircle() {
            return (CircleElement) circlePropotype.Clone();
        }

        public static ConnectorElement CreateConnector() {
            return (ConnectorElement) connectorPropotype.Clone();
        }
    }
}