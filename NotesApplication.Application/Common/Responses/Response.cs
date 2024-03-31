namespace NotesApplication.Application.Common.Responses
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public IList<string> Errors { get; set; } = new List<string>();
    }


    public class Response<TValue> : Response
    {
        public TValue? Value { get; set; }
    }
}
