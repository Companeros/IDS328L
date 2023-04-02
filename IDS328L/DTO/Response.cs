namespace IDS328L.DTO
{
    public class Response
    {
        public bool Succeded => !Errors.Any();
        public int ErrorQuery { get; set; }
        public long Identity { get; set; }
        public string StringCode { get; set; }
        public Guid GuidReturn { get; set; }
        public List<string> Errors { get; set; } = new List<string>(0);
    }

    public class Response<T> : Response where T : class
    {
        public IEnumerable<T> DataList { get; set; }
        public T SingleData { get; set; }
    }
}
