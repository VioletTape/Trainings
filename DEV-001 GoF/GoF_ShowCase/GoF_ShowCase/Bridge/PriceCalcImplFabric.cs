namespace GoF_ShowCase.Bridge {
    /*
     Для упрощения примера, список вариантов доставки зададим перечислением. Для выбора нужной реализации используем Фабричный метод
     */

    public enum DeliveryCompany {
        Self,
        CompanyA
    }

    public static class PriceCalcImplFabric {
        public static IPriceCalcImpl GetPriceCalcImpl(DeliveryCompany company) {
            switch (company) {
                case DeliveryCompany.CompanyA:
                    return new PriceCalcCompanyAImpl();

                default:
                    return new PriceCalcBaseImpl();
            }
        }
    }
}