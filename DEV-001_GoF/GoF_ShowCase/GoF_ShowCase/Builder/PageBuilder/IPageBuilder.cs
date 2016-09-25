namespace GoF_ShowCase.Builder.PageBuilder {
    public interface IPageBuilder {
        void BuildHeader(HeaderData header);
        void BuildMenu(MenuItems menuItems);
        void BuildPost(PostData post);
        void BuildFooter(FooterData footer);
    }
}