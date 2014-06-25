namespace GoF_ShowCase.ChainOfResponsibility.NearRealLife {
    public interface IOrderHandler {
        bool Process(OrderData orderData);
    }
}