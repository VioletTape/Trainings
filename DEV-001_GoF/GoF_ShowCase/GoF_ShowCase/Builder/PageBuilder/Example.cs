namespace GoF_ShowCase.Builder.PageBuilder {
    public class Example {
        public void PostPage(int pageId) {
            var pageBuilder = new PageBuilder();
            var pageDirector = new PageDirector(pageBuilder);

            pageDirector.BuildPage(pageId);


            var page = pageBuilder.GetResult();

            Display(page);
        }

        private void Display(Page page) {
            
        }

        public void Print(int pageId) {
             var pageBuilder = new PrintPageBuilder();
            var pageDirector = new PageDirector(pageBuilder);

            pageDirector.BuildPage(pageId);

            var page = pageBuilder.GetResult();

            Display(page);
        }
    }
}