namespace NotesApplication.Application.Common.Responses
{
    /// <summary>
    /// Результат запроса
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Успешно ли выполнился запрос
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Список сообщений об ошибках
        /// </summary>
        public IList<string> Errors { get; set; } = new List<string>();
    }

    /// <summary>
    /// Результат запроса
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class Response<TValue> : Response
    {
        public TValue? Value { get; set; }
    }
}
