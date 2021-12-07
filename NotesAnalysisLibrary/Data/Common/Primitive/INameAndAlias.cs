namespace NotesAnalysisLibrary.Data.Common.Primitive {
    public interface INameAndAlias {
        /// <summary>
        /// 名前
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 別名
        /// </summary>
        string Alias { get; set; }
    }
}