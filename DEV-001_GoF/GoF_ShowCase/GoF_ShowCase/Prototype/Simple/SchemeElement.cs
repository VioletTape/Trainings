namespace GoF_ShowCase.Prototype.Simple {
    public abstract class SchemeElement {
        public uint Id { get; set; }
        public string Title { get; set; }

        public virtual SchemeElement Clone() {
            return (SchemeElement) MemberwiseClone();
        }
    }
}