namespace GoF_ShowCase.ChainOfResponsibility.GroupDelegates {
    public interface IOrderHandler {
        bool Process(OrderData orderData);
    }
}