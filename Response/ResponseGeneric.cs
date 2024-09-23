namespace ApiPersonas.Response
{
    public class ResponseGeneric <T> 
    {
        public T Data { get; set; }
        public Exception Ex { get; set; }
        public string Message { get; set; }

        //public bool Success { get; set; }
        public string codeMessage { get; set; }
    }
}
